# BaWo API Project:

## META INFO:
BaWo Project Stages: *early* | mid | late | beta

Golden Hands Stages: postponed until BaWo is nearing completion

##	ABOUT PROJECT:
Ever needed to simulate a vast world, interacting with itself in the
background of a visual one? That is the problem BaWo is trying to solve!

###	Introduction
The "BaWo - Background World" API will in its final stage be applicable to any C# project
that needs to generate characters, organizations and locations, while simulating their global 
interactions in the background. The API will handle automatically all background artifical 
intelligence, procedural content creation, data management and simplify data storage. All you
need to do is to run the methods from Command.cs to steer. Alternatively, you'll also have 
access to the DataBank where you can create or change content manually.

To setup for your own use, you only need to run:

    Command.SetupModules(
		"\characterModules\",
		"\organizationModules\",
		"\locationModules\");

The string values above are examples of folders where all the JSON-defined
modules for your game will lie. JSON modules made for the game Golden Hands
will be available at this repo for free, to get you started.

After finishing setting up the JSON assets, you'll also have to run these
to get your background world up and running:
* Command.SetupGame(Command.WorldRecipe wr, Command.PlayerRecipe pd)
  * for multiplayer treat second parameter as *Command.PlayerRecipe[] pd*
* *optional* Command.SetMinimumTickRate(float seconds) - default is 0.5f
* Command.Start() - starts ticking

You'll then have the ability to anytime later run:
* Command.Pause() - stops ticking
* string Command.GetWorldJSON() - all world data as one huge JSON, use it for save files
* string Command.GetPlayerJSON(uint playerNumber = 0) - all player data as a JSON, use it for save files

And if you already have a saved world:
* Command.SetupGameFromJSON(string world, string player)
  * for multiplayer treat second parameter as *string[] players*

### Create feature- and content game expansions using *only JSON*!
Central to BaWo will be the ability to generate background content with
minimal effort. This also includes entirely new types of background content
and behaviour. To do this, you define a module with JSON. A module has two
core aspects that need specification:
- generation: what rules follows its random assembling?
- cataloguing: what situations, options and forecasts does it add to the catalogue?

Beyond this, the JSON needs to be consistent, meaning that you'll get
an error message if you try to setup up any module that prescribes
situations and options upon its creation that do not exist.

##  ARCHITECTURAL DESCRIPTION:
BaWo Management Tool (Command.cs - not implemented yet)
* runs setup for central objects
* controls speed and ticks of the game
* runs UpdateTime on DataBank.cs, UpdateBehaviour on AI.cs and UpdateLuck on Fate.cs

AI Engine (AI.cs - nearing completion)
* defines and creates sets of options for each tick of the game
* makes choices for character until it runs out of willpower

Fate Engine (Fate.cs - not implemented yet)
* steers happenings in the game that are outside the 
  control of any character

Entities (Entity.cs - early implementation)
* defines data about in-game entities, includes 
  characters, organizations and locations

Data Bank (DataBank.cs - midway implementation)
* stores all data and gives easy access to it

Catalogues (Catalogue.cs - early implementation)
* contains templates for new entities

Generator (Generator.cs - early implementation)
* classes for randomly generating content

Information feeding (Feeder.cs - not implemented yet)
* provides methods for automatically formatting, collecting
  and channelling information feed from DataBank to display
  in a visual game world or on the GUI

Interaction response (Responder.cs - not implemented yet)
* provides methods for responding to user interaction with
  searching-, -adding, -modifying or -changing data

##	DATA FLOWS
Each of the following categories refer to times
when data is created or changed, and specifies: 
* what data is created and changed,
* by what is it created or changed, and
* for what purpose is it created or changed

### START
The developer can allow the player starts a game by setting up the world and the 
player character, or configure these themselves. Anyway, these must be specified:
* The World:
  * World Foreground Population (characters that can be interacted with)
  * World Background Population (non-interactable, only relevant for statistics)
	* World Organization Quantity
	* World Location Quantity
* Player Character:
  * The module ID of any module data that the player should be able to choose.
    Unless all module IDs are included, remaining modules will be generated randomly.

This data is then loaded by the Game Manager on start as
PlayerCharacterRecipe and WorldRecipe, with subsequent calls
to the functions Generator.World.Generate(WorldRecipe) and
Generator.Character.GeneratePlayer(PlayerCharacterRecipe).

### TICKS
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
There are two types of actions the player can take in the game that changes data:
* choose new Options as long as there is enough willpower points
  to do so (choosing an Option creates new Options, Situations
  and Forecasts for player character)
* regret (abort) the Situation marked as "activity", which is
  the Situation describing what the player character is currently
  doing (this will leave the player character without an activity
  Situation, automatically giving it the "procrastinating" Situation)

BaWo also allows the character to actively:
* use the search engine to search the world for entities,
  inspect them and retrieve data from them
* increase or reduce minimum tick speed of game
* pause/continue game
* choose different parts of oneself or different parts
  of another entitiy to view, basically switch between
  different data sections/data views

#	Golden Hands - From Nowhere to Anywhere (a BaWo-based game)

##	ABOUT GAME:
In Golden Hands you explore life while trying to push yourself
to the very limits of what it has to offer. You start with nothing, 
but with the potential to become anything. What will you be?
Who will you meet? Where will you end up?

Overcome your biological- and social heritage by defying the world,
shaping successful businesses, organizations and spreading joy and
happiness about the world as you do so.

Show the world that you truly have ***golden hands***.