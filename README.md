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
* runs UpdateBehaviour on AI.cs, UpdateTime on DataBank.cs, UpdateLuck on Fate.cs

AI Engines (AI.cs)
* defines and creates sets of options for each tick of the game
* makes choices for character until it runs out of willpower

Fate Engines (not implemented yet)
* controls happenings in the game that are outside the control
  of any character

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
The player starts a game by setting up the world and the player character. 
To do this, the player specifies the following data:
* The World:
  * Exact Number Attributes:
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
The game has two types of major change determinators: character behaviour and fate's course.
Both types are dealt with by a static class each, defined in the AI.cs and Fate.cs files.
The first one deals with the simulation of human behaviour, while the other deals with happenings 
outside of any character's control, a.k.a. "fate", "nature's course" or "the will of god".

Characters, organizations and locations are made up of modules that each handle a category
of data. Both AI.cs and Fate.cs run functions on these modules, fetching three types of 
objects from them. These are then processed, before new such objects are sent back.
The three types are:
* Situations - Describes the status of the character in terms of tags and attribute values
* Options - Describes actions the character can take, to get new situations and new options
* Forecasts - Describes what can happen to the character in the future, ergo fate's options

During every game tick (represents 1 hour of virtual time), two primary 
operations are ran by GameManager.cs on the following classes:
* DataBank.cs
  * Runs UpdateTime(DateTime) which iterates over all characters, organizations and locations.
    These entities then run UpdateTime(DateTime) on all modules. Each module checks if any 
    Situation is past expiration date, and if so, runs Terminated() which launches any new 
    Situations, Options or Forecasts. Any expired Situations are then deleted.
* AI.cs
  * Runs UpdateBehaviour() which iterates over all characters (only). Characters then run
    UpdateBehaviour() on all modules. Each module can then load AI.cs with data about
    options and/or option value. AI.cs then produces a priority queue of options sorted
	lowest to highest by willpower cost, which is option value divided by the option's 
	base value. Chosen() is then ran on options from the queue until all character 
	"Willpower points" are spent.

Additionally, once a day at night, the following extra operation is ran:
* Fate.cs
  * Runs UpdateLuck() which iterates over all characters and organizations (only).
    These entities then run UpdateLuck() on all modules. Each module can then load
    Fate.cs with data about Forecasts. Each Forecast has a "Fortune" integer value 
    related to it describing how good (positive value) or bad (negative value) it is.
    Fate.cs then generates a semi-random number (from predefined list with bias
    towards zero) for both positive and negative fortune, before randomly selecting 
    eligible Forecasts for each type until the combined positive and negative values 
    either match the randomly generated numbers, or there are no more Forecasts to 
    choose from. Destiny() is then ran on the selected Forecasts, creating new
    Situations, Options and Forecasts.


### PLAYER INTERACTION
There are two types of actions the player
can take in the game that changes data:
* choose new Options, which in turn creates new Options,
  Situations and Forecasts
* regret (abort) the Situation marked as "activity", which is
  the Situation describing what the player character is currently
  doing (this will leave the player character without an activity 
  Situation, automatically giving it the "procrastinating" Situation)

The character can also actively:
* use a search engine to search the world for entities, 
  inspect them and retrieve data from them
* increase or reduce minimum tick speed of game
* pause/continue game
* choose different parts of oneself or different parts
  of another entitiy to view, basically switch between
  different data sections/data views