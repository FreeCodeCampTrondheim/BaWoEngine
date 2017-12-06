# BaWo Engine Project:

## META INFO:
BaWo Project Stages: *early* | mid | late | beta

This project is the basis for the following future projects:
* BaWo Module Creator - web tool for crafting JSON modules
* Golden Hands - a BaWo-based game about human potential

##	ABOUT PROJECT:
Ever needed to simulate a vast world, interacting with itself in the
background of a visual one? That is what BaWo is for!

###	Introduction
The "BaWo - Background World" Engine will in its final stage be applicable to any C# project
that needs to generate characters, organizations and locations, while simulating their global 
interactions in the background. The engine will handle automatically all background artifical 
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
will be available at this repo for free, to get you started. A JSON module
folder contains four .json files with the following names:

* "module"
  * describes how the module affects character generation, data viewing
    and player interaction
* "situations"
  * a JSON array of descriptions of situations the module adds to the catalogue
* "options"
  * same as above but for options
* "forecasts"
  * same as above but for forecasts

After finishing setting up the JSON assets, you'll also have to run these
to get your background world up and running:
* Command.SetupGame(Command.WorldRecipe wr, Command.PlayerRecipe pd)
  * for multiplayer treat second parameter as *Command.PlayerRecipe[] pd*
* *optional* Command.SetMinimumTickRate(float seconds) - default is 1.0f
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
and behaviour. To do this, you define a module with JSON. A module has four
core aspects that need specification:
- generation: what rules follows its random assembling?
- data viewing: how should the module be represented when data is to be shown?
- player interaction: how should the module respond to player interactions with the background world?
- cataloguing: what situations, options and forecasts does it add to the catalogue?

Beyond this, the JSON needs to be consistent, meaning that you should
get an error message if you try to setup up any module that prescribes
situations and options upon its creation that do not exist.

##  More Information
* See *Architecture.md* for a description of project files and their purpose
* See *DataFlows.md* for a description of how data is created and changed
* See *How to write JSON modules.md* for a guide on how to expand content possibilities in BaWo