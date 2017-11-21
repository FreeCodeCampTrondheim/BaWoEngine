#	Golden Hands - From Nowhere to Anywhere

###	ABOUT GAME:
In Golden Hands you explore life while trying to push yourself
to the very limits of what it has to offer. You start with nothing, 
but with the potential to become anything. What will you be?
Who will you meet? Where will you end up?

Overcome your biological- and social heritage by defying the world,
shaping successful businesses, organizations and spreading joy and
happiness about the world as you do so.

Show the world that you truly have ***golden hands***.

##  ARCHITECTURAL DESCRIPTION:
Game Manager (not implemented yet, reserved for later because it's trivial and may change alot)
* runs setup for central objects
* controls speed and ticks of the game
* runs UpdateBehaviour on AI, and UpdateData on Data Bank

AI Engines (AI.cs)
* defines and creates sets of options for each tick of the game 
* chooses an option at a time, but makes a variable amount of 
  choices after each other

Entities (E.cs)
* defines data about in-game entities

Data Bank (DataBank.cs)
* stores all data and gives easy access to it

Catalogues (C.cs)
* contains templates for new entities

Generator (G.cs)
* classes for randomly generating content

Player (InformationFeeder.cs and InteractionResponder.cs)
* defines all possible responses to user actions, like retrieving data and applying choices
* defines all automated tasks done for the user
* includes searching, various information feeds, character creation, user choices and so forth

##	DATA FLOWS
Each of the following categories refer to times
when data is created or changed, and specifies: 
* what data is created and changed,
* by what is it created or changed, and
* for what purpose is it created or changed

### GAME START
The player starts a game by setting up the world and the 
player character. To do this the following data is specified:
* World:
  * By Exact Number:
    * World Foreground Population (characters that can be interacted with)
    * World Background Population (non-interactable, only relevant for statistics)
	* World Organization Quantity
	* World Location Quantity
* Player Character:
  * Name
  * Age
  * Gender

This data is then loaded by the Game Manager on start as
PlayerCharacterRecipe and WorldRecipe, with subsequent calls
to the functions G.WorldGenerator.Generate(WorldRecipe) and
G.CharacterGenerator.GeneratePlayer(PlayerCharacterRecipe).

### GAME TICKS
ff

### PLAYER INTERACTION
ff

##	SCRIBBLES AND NOTES:
Situations need to have an origin
- can be:
  - character (also includes specification of which)
  - organization (also includes specification of which)
  - luck
  - mystery

Situations need to have descriptors/tags that categorizes them

Options need to add and subtract other options???

Options need personalization method that adjusts variables for specific characters or organizations

Options to be separated into
- character options, what options characters have, they choose based on:
  - mental focus targets and their focus degree
  - emotions and their weights
  - how much they like or dislike the targets of the situations
- organization options, what options organizations have, they choose based on:
  - how many of the owning characters are willing to support the option
- luck options, what options nature has, it chooses based on:
  - base likelihood weight
  - aggragate likelihood weight from organization- and location statistics


Characters need list of emotions and emotional weight/value

Characters need list of mental focus targets
- can be:
  - characters
  - organizations
  - locations
  - options
  - situations
- mental focus towards a target is aggregated for every situation with that target as an origin

Characters need heritage that modifies base statistics
- when players create their character, they have a max amount
  of points they can use to add advantage through these,
  the available amount depends on difficulty setting,
  and adding disadvantage gives back extra points
- comes with two types:
  - biological
  - social