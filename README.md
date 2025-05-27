# ProjectRPG

Team Members Assigned Features:

Stats and Leveling, Move character, Respawn - Caleb
Stat Saving, Interaction, Saving Options - Zach
Camera Control, Menu & Option, Dialogue - Jasper

## Menu and options Menu – Zach
> This feature allows the player to start a new game, 
load the game and exit by clicking on the Main menu, 
the options menu’s intended purpose is to allow players 
to adjust sound settings, graphic preferences and gameplay 
settings in the game.
>

## Saving and Loading Options – Zach
> This feature lets players save their menu preferences, 
game progress and stats allowing them to continue playing 
with their chosen preferences loaded when the game starts, 
the system will store the preferences in a file, this allows 
for easy retrieval and modifications of the save file.
>

## Player Movement – Caleb
> This allows the player to move around in the game,
every time they press the WASD or Arrow keys on the Keyboard.
The player can press the left shift key to sprint and the left 
ctrl key to crouch with their own speeds. 
The movement will be smooth and responsive with a collision 
system to prevent players from passing through objects uncontrollably.
>

## Camera Control – Jasper
> The Camera will follow the player, as the player moves, the camera’s
rotation and position will adjust accordingly to the player’s movements 
ensuring that they get a clear view of the actions happening in game. 
The player can also change the camera angle and zoom in by using the mouse.
>

## Dialogue System – Jasper 
> This allows players to read through text based dialogue and make choices
using the dialogue options that will effect the player’s interaction in the game.
>

## Interaction – Jasper 
> The player can interact with NPCs, objects and environments 
with the use of prompts. These interactions will trigger actions
like opening boxes, picking up items or starting a conversation 
using dialogues. The interaction system will be simple and context 
sensitive, adapting to the object or NPC being interacted with.
>

## Stats and Leveling – Caleb
> The player will have stats like health, experience points and
level which will increase as they play the game, the leveling
system will increase stats as the player earns experience points.
>

## Saving and Loading Stats – Zach 
> Player stats will be saved during the game save process. 
Stats will be stored in a file for easy management and access
when loading the game. 
Any changes made to the players stats like leveling up will
auto save, the Auto save feature will also save the player’s 
current position, rotation and other transform related data.
When the game is loaded the game will fetch the players last 
location and state allowing the game to continue where the 
player left it at. 
> 

## Respawn – Caleb 
> When the player’s character dies they will respawn at a
predefined location like a checkpoint or starting area, 
once they respawn their health and will return to its 
default value. The respawn system will have a short 
delay before the player returns to the world to prevent 
the player from instantly respawning. The game will have 
a visual or audio cue to tell the player that they are respawning. 
Player stats will stay with the player’s progression despite death.
>



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
