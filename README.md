# The101Box — User Manual
**Version 3.0 RC1 — by Kees, ON9KVE**

---

## What is it?
The101Box is a compact CAT controller for the **Yaesu FTDX101D/MP** transceiver. It connects via a serial (COM) port and gives you fast access to the most-used controls from your PC screen.

---

## Connection
1. Select the correct **COM port** from the dropdown at the top
2. Click **Connect** to start communication
3. The app immediately reads all settings from the radio and updates the display

> The app can only run **one instance at a time**

---

## Frequency Display
| Control | Action |
|---------|--------|
| **MAIN** frequency box (Silver) | Click → switches radio focus to MAIN |
| **SUB** frequency box (Blue) | Click → switches radio focus to SUB |

The active receiver matches the radio's own display colors: **Silver = MAIN**, **Blue = SUB**.

---

## Sliders
All sliders are **bidirectional** — they follow knob changes on the radio in real time.
**Right-click** any slider to reset it to its default value.

| Slider | Function | Right-click resets to |
|--------|----------|-----------------------|
| **RF Gain** | Main RF gain (RG) | — |
| **Volume** | Main audio volume (AG) | — |
| **Power** | TX output power (PC) | — |
| **WIDTH** | IF bandwidth (SH) | SSB: 3000 Hz / CW: 600 Hz |
| **SHIFT** | IF passband shift (IS) ±1200 Hz | 0 Hz |

Slider and label colors follow receiver focus: **Silver = MAIN active**, **Dark Blue = SUB active**.

---

## Mode Buttons
**LSB / USB / CW / FM / AM / DIG** — sets the mode of the active receiver (MAIN or SUB).

---

## Antenna & Preamp
| Button | Function |
|--------|----------|
| **ANT1 / ANT2** | Select antenna 1 or 2 |
| **ANT3/RX** | Select RX-only antenna |
| **IPO** | Toggle IPO (preamp bypass) |
| **AMP1 / AMP2** | Toggle preamplifier 1 or 2 |

---

## Attenuator
**ATT 0 / 6 / 12 / 18** — sets the attenuator level (0, 6, 12 or 18 dB) for the active receiver.

---

## DSP
| Button | Function |
|--------|----------|
| **DNR** | Toggle Digital Noise Reduction |
| **DNF** | Toggle Digital Notch Filter |

---

## Spectrum Display Mode
| Button | Function |
|--------|----------|
| **CENTER** | Spectrum in center mode |
| **CURSOR** | Spectrum in cursor mode |
| **FIX** | Spectrum in fixed mode |

---

## SSB Preset Frequencies
**SSB1 – SSB6** — six programmable band/frequency presets, applied to the active receiver.

---

## RX Routing
| Button | Function |
|--------|----------|
| **MAIN RX** | Toggle MAIN antenna routing |
| **SUB RX** | Toggle SUB antenna routing |

Colors: **ON = Silver/DarkBlue**, **OFF = DarkGreen/Yellow**

---

## Internal Tuner
| Button | Function |
|--------|----------|
| **Tune** | Start + engage internal tuner |
| **On** | Engage tuner only |
| **Off** | Bypass tuner |

---

## Level (LEV) / RF Squelch
- **LEV +/−/RESET** — adjusts the signal level threshold for the active receiver
- **RF SQL** button toggles RF squelch on/off

---

## SWAP
Swaps MAIN and SUB VFO frequencies.

---

## Band / Step
- **BAND** label shows the current band (e.g. 40m, 20m) based on active frequency
- **Step** dropdown sets the tuning step for the active VFO — remembered separately for MAIN and SUB

---

## Temperature
The **TEMP** box shows the internal PA temperature. Click the clear button next to it to reset the display.

---

## Notes
- All controls apply to the **active receiver** (MAIN or SUB) unless otherwise noted
- The WIDTH display shows fixed values for AM (9000 Hz) and FM (16000 Hz) — these cannot be changed on the radio
- Settings (step, COM port) are saved locally between sessions
- The app supports both **FTDX101D** and **FTDX101MP**

---

*73 de ON9KVE*
