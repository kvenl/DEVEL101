# Copilot Instructions

## General Guidelines
- Respond in English and ignore Dutch for now.
- My name is Kees.
- All code suggestions should indicate the document where the code should be applied.
- Never commit Git changes without Kees's explicit consent/request.

## Git Procedures
- To discard all uncommitted changes and revert to the last commit in Visual Studio: 
  1. Open the Terminal window (__View > Terminal__). 
  2. Run: `git reset --hard HEAD`. This permanently deletes uncommitted changes. 
- To check sync with GitHub: 
  1. Run `git fetch origin`. 
  2. Run `git status`. If it shows "Your branch is up to date with 'origin/master'.", it's synced. 
  3. Alternatively, in __Git Changes__ window, click the branch name for ahead/behind info.

## Application Controls
- Kees has restyled the application and added/changed many buttons and textboxes. Future requests will reference these controls by their names, which may sometimes be changed. Changes should be made based on these references.