# ProjectRPG

Team Members Assigned Features:

Stats and Leveling, Move character, Respawn - Caleb
Stat Saving, Interaction, Saving Options - Zach
Camera Control, Menu & Option, Dialogue - Jasper





## Naming Conventions
### Folders
 Will be named using Pascal Casing, then we start with the Scene, then Mechanic, then relevent Data.

i.e. Game/Player/Health or Trap/Spring
### Scripts
Within the namespace it should be relatively clear ```SaveMenu```, ```Health```, and so on that people can understand what the script is about.
### Branch
Using - instead of spaces due to github restrictions, pressing space will automatically add it.
* main
    * The branch containing the production version of the game.
* dev
    * The branch where new features and bug fixes are merged and tested.
* feature/xyz
    * The branch used to develop a new feature. Such as feature/dialogue-system.
* bugfix/xyz
    * The branch used to work on a bugfix, such as bugfix/inventory-infinite-money-error.
## Text Files
Primarily will be using ```JSON```.
