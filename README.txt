Game created for Keio-NUS Cute Center Software Programmer Application by Franklin Lim

Disclaimer:
Most art and music assets are taken from Unity Asset Store but all scripts are written by myself. Github commits are done once I stop work after a session so there may not be as many commits.

High Concept:
A deckbuilding card auto-battler

Gameplay:
Place cards drawn on to the first row of the battlefield to summon them. They will walk towards the enemy and attack if possible. Once a unit attacks, it cannot move for that turn. Cards cost mana which is shown on the HUD at the side of the screen. Mana and Cards are replenished at the end of the turn. Once a unit reaches the last row, it will die but also deal damage, equal to its mana cost, to the enemy main healthbar.

Map:
Map allows for choosing which battles to go into and which event to activate. Simply click on the arrow of the direction you wish to go. The star indicats where you are currently at. Map currently has limited events as this is more of a demo showcase rather than a full game.

Assignment:
Controls: Gameplay uses mouse to click and select
Feedback: Animations for attack, move and die are included with audio attacking feedback. Click sounds also added for menu options and some card clicks
UI: HUD for Health and mana included and there is a main menu as well.
Objectives: There is a win objective by reducing enemy health to 0

Extra Credits:
Load/Save Game: Saving and Loading is automatically done after each map event is complete. However, if you quit game during battle you will have to restart the battle. Save progress is also reset once you win or lose the game.
Level Progression: Map has been implemented which provides 3 stages of battle and 2 other events
Ability to change gameplay without recompiling: Unit data is stored in a scriptable object which allows for changing its stats by modifying that file itself

