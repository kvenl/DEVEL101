using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DEVEL101
{
    /// <summary>
    /// A fully owner-drawn TrackBar replacement that exposes
    /// <see cref="TickColor"/> and <see cref="ChannelColor"/> properties.
    /// </summary>
    public class CustomTrackBar : Control, ISupportInitialize
    {
        private int         _minimum        = 0;
        private int         _maximum        = 10;
        private int         _value          = 0;
        private int         _tickFrequency  = 1;
        private TickStyle   _tickStyle      = TickStyle.BottomRight;
        private Orientation _orientation    = Orientation.Horizontal;
        private Color       _tickColor      = Color.White;
        private Color       _channelColor   = Color.Gray;
        private bool        _initializing   = false;
        private bool        _isDragging     = false;

        // Layout constants
        private const int ThumbHalfWidth    = 8;   // half-width of thumb (perpendicular to track)
        private const int ThumbHalfLength   = 5;   // half-length of thumb (along track)
        private const int ChannelHalfWidth  = 2;   // half-width of the channel groove
        private const int TickLen           = 4;   // tick mark length in pixels
        private const int TickGap           = 2;   // gap between thumb edge and tick start

        public event EventHandler ValueChanged;

        public CustomTrackBar()
        {
            SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.ResizeRedraw, true);
            TabStop = true;
        }

        // ── Properties ────────────────────────────────────────────────────

        [DefaultValue(0)]
        public int Minimum
        {
            get => _minimum;
            set { _minimum = value; if (!_initializing) { CoerceValue(); Invalidate(); } }
        }

        [DefaultValue(10)]
        public int Maximum
        {
            get => _maximum;
            set { _maximum = value; if (!_initializing) { CoerceValue(); Invalidate(); } }
        }

        [DefaultValue(0)]
        public int Value
        {
            get => _value;
            set
            {
                int v = Math.Max(_minimum, Math.Min(_maximum, value));
                if (_value == v) return;
                _value = v;
                ValueChanged?.Invoke(this, EventArgs.Empty);
                Invalidate();
            }
        }

        [DefaultValue(1)]
        public int TickFrequency
        {
            get => _tickFrequency;
            set { _tickFrequency = Math.Max(1, value); Invalidate(); }
        }

        [DefaultValue(TickStyle.BottomRight)]
        public TickStyle TickStyle
        {
            get => _tickStyle;
            set { _tickStyle = value; Invalidate(); }
        }

        [DefaultValue(Orientation.Horizontal)]
        public Orientation Orientation
        {
            get => _orientation;
            set { _orientation = value; Invalidate(); }
        }

        /// <summary>Color used to draw the tick marks.</summary>
        public Color TickColor
        {
            get => _tickColor;
            set { _tickColor = value; Invalidate(); }
        }

        /// <summary>Color used to draw the channel (groove) line.</summary>
        public Color ChannelColor
        {
            get => _channelColor;
            set { _channelColor = value; Invalidate(); }
        }

        // ── Painting ──────────────────────────────────────────────────────

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.Clear(BackColor);
            if (_orientation == Orientation.Vertical)
                DrawVertical(e.Graphics);
            else
                DrawHorizontal(e.Graphics);
        }

        private void DrawVertical(Graphics g)
        {
            int cx         = Width / 2;
            int trackTop   = ThumbHalfLength + 2;
            int trackBottom = Height - trackTop;
            int trackLen   = trackBottom - trackTop;

            // Channel groove
            using (var brush = new SolidBrush(_channelColor))
                g.FillRectangle(brush, cx - ChannelHalfWidth, trackTop, ChannelHalfWidth * 2, trackLen);

            // Tick marks
            if (_tickStyle != TickStyle.None && _tickFrequency > 0)
            {
                int range = _maximum - _minimum;
                using (var pen = new Pen(_tickColor, 1))
                {
                    for (int tick = _minimum; tick <= _maximum; tick += _tickFrequency)
                    {
                        float py = range > 0
                            ? trackTop + trackLen * (1f - (float)(tick - _minimum) / range)
                            : trackTop;
                        DrawVTick(g, pen, cx, py);
                    }
                    // Ensure the maximum tick is always drawn
                    if ((_maximum - _minimum) % _tickFrequency != 0)
                        DrawVTick(g, pen, cx, trackTop);
                }
            }

            // Thumb
            int ty = GetThumbPixel(trackTop, trackLen, invert: true);
            DrawThumb(g, new Rectangle(cx - ThumbHalfWidth, ty - ThumbHalfLength,
                                       ThumbHalfWidth * 2, ThumbHalfLength * 2));
        }

        private void DrawVTick(Graphics g, Pen pen, int cx, float py)
        {
            if (_tickStyle == TickStyle.TopLeft || _tickStyle == TickStyle.Both)
                g.DrawLine(pen,
                    cx - ThumbHalfWidth - TickGap - TickLen, py,
                    cx - ThumbHalfWidth - TickGap, py);
            if (_tickStyle == TickStyle.BottomRight || _tickStyle == TickStyle.Both)
                g.DrawLine(pen,
                    cx + ThumbHalfWidth + TickGap, py,
                    cx + ThumbHalfWidth + TickGap + TickLen, py);
        }

        private void DrawHorizontal(Graphics g)
        {
            int cy        = Height / 2;
            int trackLeft  = ThumbHalfLength + 2;
            int trackRight = Width - trackLeft;
            int trackLen   = trackRight - trackLeft;

            // Channel groove
            using (var brush = new SolidBrush(_channelColor))
                g.FillRectangle(brush, trackLeft, cy - ChannelHalfWidth, trackLen, ChannelHalfWidth * 2);

            // Tick marks
            if (_tickStyle != TickStyle.None && _tickFrequency > 0)
            {
                int range = _maximum - _minimum;
                using (var pen = new Pen(_tickColor, 1))
                {
                    for (int tick = _minimum; tick <= _maximum; tick += _tickFrequency)
                    {
                        float px = range > 0
                            ? trackLeft + trackLen * (float)(tick - _minimum) / range
                            : trackLeft;
                        DrawHTick(g, pen, cy, px);
                    }
                    if ((_maximum - _minimum) % _tickFrequency != 0)
                        DrawHTick(g, pen, cy, trackRight);
                }
            }

            // Thumb
            int tx = GetThumbPixel(trackLeft, trackLen, invert: false);
            DrawThumb(g, new Rectangle(tx - ThumbHalfLength, cy - ThumbHalfWidth,
                                       ThumbHalfLength * 2, ThumbHalfWidth * 2));
        }

        private void DrawHTick(Graphics g, Pen pen, int cy, float px)
        {
            if (_tickStyle == TickStyle.TopLeft || _tickStyle == TickStyle.Both)
                g.DrawLine(pen,
                    px, cy - ThumbHalfWidth - TickGap - TickLen,
                    px, cy - ThumbHalfWidth - TickGap);
            if (_tickStyle == TickStyle.BottomRight || _tickStyle == TickStyle.Both)
                g.DrawLine(pen,
                    px, cy + ThumbHalfWidth + TickGap,
                    px, cy + ThumbHalfWidth + TickGap + TickLen);
        }

        private int GetThumbPixel(int trackStart, int trackLen, bool invert)
        {
            int range = _maximum - _minimum;
            if (range == 0) return trackStart;
            float ratio = (float)(_value - _minimum) / range;
            if (invert) ratio = 1f - ratio;
            return trackStart + (int)(ratio * trackLen);
        }

        private void DrawThumb(Graphics g, Rectangle r)
        {
            using (var brush = new SolidBrush(ForeColor))
                g.FillRectangle(brush, r);
            using (var pen = new Pen(Color.Black, 1))
                g.DrawRectangle(pen, r);
        }

        // ── Mouse & Keyboard input ─────────────────────────────────────────

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                _isDragging = true;
                Focus();
                UpdateValueFromMouse(e.Location);
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (_isDragging && e.Button == MouseButtons.Left)
                UpdateValueFromMouse(e.Location);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            _isDragging = false;
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
            Value = Math.Max(_minimum, Math.Min(_maximum, _value + (e.Delta > 0 ? 1 : -1)));
        }

        private void UpdateValueFromMouse(Point pt)
        {
            if (_orientation == Orientation.Vertical)
            {
                int trackTop = ThumbHalfLength + 2;
                int trackLen = Height - trackTop * 2;
                if (trackLen <= 0) return;
                float ratio = 1f - (float)(pt.Y - trackTop) / trackLen;
                Value = _minimum + (int)Math.Round(Math.Clamp(ratio, 0f, 1f) * (_maximum - _minimum));
            }
            else
            {
                int trackLeft = ThumbHalfLength + 2;
                int trackLen  = Width - trackLeft * 2;
                if (trackLen <= 0) return;
                float ratio = (float)(pt.X - trackLeft) / trackLen;
                Value = _minimum + (int)Math.Round(Math.Clamp(ratio, 0f, 1f) * (_maximum - _minimum));
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            switch (e.KeyCode)
            {
                case Keys.Up:    case Keys.Right:   Value = Math.Min(_maximum, _value + 1);              break;
                case Keys.Down:  case Keys.Left:    Value = Math.Max(_minimum, _value - 1);              break;
                case Keys.PageUp:                   Value = Math.Min(_maximum, _value + _tickFrequency); break;
                case Keys.PageDown:                 Value = Math.Max(_minimum, _value - _tickFrequency); break;
                case Keys.Home:                     Value = _minimum;                                    break;
                case Keys.End:                      Value = _maximum;                                    break;
            }
        }

        // ── ISupportInitialize ─────────────────────────────────────────────

        void ISupportInitialize.BeginInit() => _initializing = true;

        void ISupportInitialize.EndInit()
        {
            _initializing = false;
            CoerceValue();
            Invalidate();
        }

        private void CoerceValue() =>
            _value = Math.Max(_minimum, Math.Min(_maximum, _value));
    }
}
