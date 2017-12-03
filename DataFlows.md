##	Data Flows
Each of the following categories refer to times
when data is created or changed, and specifies: 
* what data is created and changed,
* by what is it created or changed, and
* for what purpose is it created or changed

### START
The developer can either give the player readily defined worlds and characters, or
they can allow the player to start a game by setting up all, or parts of it themselves. 
Anyway, what is not specified by either player or developer follows normal rules of random
generation or are assigned default values, but at minimum these should be specified:
* The World:
  * World Foreground Population (characters that can be interacted with)
  * World Background Population (non-interactable, only relevant for statistics)
	* World Organization Quantity
	* World Location Quantity
* Player Character:
  * Enter the module IDs that are not to be generated, and then give all options
    and situations the player should start with.

This data is then sent to Generator.cs to call the subsequent functions:
* Generator.World.Generate(WorldRecipe) and
* Generator.Character.Generate(PlayerCharacterRecipe).

### TICKS
BaWo has two types of major change determinators: character behaviour and fate's course.
Both types are dealt with by a static class each, defined in the AI.cs and Fate.cs files.
The first one deals with the simulation of human behaviour, while the other deals with happenings
outside of any character's control, a.k.a. "fate", "nature's course" or "the will of god".

Characters, organizations and locations are created from modules that each define a category
of data. Both AI.cs and Fate.cs run functions on the entities, fetching three types of objects 
from them that at some point came into existence as a cause of data provided about the module
setup. These data are then processed, before new such objects are sent back.
The three types are:
* Situations
  * Describes the status of the character in terms of tags, value tags and stats
  * Upon termination, can launch new situations, -options and -forecasts
* Options
  * Describes actions the character can take
  * Choosing an option launches new situations, -options and -forecasts
* Forecasts
  * Describes what can happen to the character in the future
  * If played out, new situations, -options and -forecasts will be launched

During every tick (represents a unit of virtual game time, for instance an hour),
two primary operations are ran by Command.cs on the following classes:
* DataBank.cs
  * Runs UpdateTime(DateTime) which iterates over all characters, organizations and locations.
    These entities then run UpdateTime(DateTime) on all situations. If any Situation is past 
    expiration date, it runs Terminated() which can launch new Situations, Options or Forecasts. 
    Expired Situations are then deleted.
* AI.cs
  * Runs UpdateBehaviour() which iterates over all characters (only). AI.cs then retrieves
    data about Options and/or Option value, before producing a queue of Options sorted
	  lowest to highest by willpower cost, which is Option value divided by the option's
	  base cost. Chosen() is then ran on Options from the queue until all character
	  "Willpower points" are spent. From this, new Situations, Options and Forecasts
    come into being. Any chosen Options are then removed from player character.

Additionally, once every 24 ticks by default, the following extra operations are ran:
* Fate.cs
  * Runs UpdateLuck() which iterates over all characters and organizations (only).
    Fate.cs then retrieves data about Forecasts. Each Forecast has a "Fortune" integer
    value related to it describing how good (positive value) or bad (negative value) 
    it is. A semi-random number (from predefined list with bias towards zero) is
    generated for both positive and negative fortune. Two lists are then created, one
    for positive- and one for negative fortune, and existing Forecasts are then randomly 
    positioned in the two lists but based on either type. Thereafter, as the lists are
    completely filled with all character Forecasts, they are extracted from and added to 
    a final list until either the combined fortune of both positive- and negative type
    match the randomly genearted numbers, or the list of the respective type is completely
    empty. On each of the two remaining final lists, the PlayOut() is then ran on contained 
    Forecasts, creating new Situations, Options and Forecasts. Any played out Forecasts 
    are then removed from the player character.

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