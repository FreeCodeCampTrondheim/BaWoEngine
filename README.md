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
of data. Both AI.cs and Fate.cs run functions on these modules, fetching data about three
types of data objects from them, processing it, and then storing new such data objects.
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
    options and/or option value. AI.cs then produces a priority queue from option value
    with highest first, before running Chosen() on options from the queue until all
    character "Willpower points" are spent.

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