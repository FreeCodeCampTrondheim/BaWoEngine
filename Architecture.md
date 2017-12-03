##  Architectural Description:
BaWo Management Tool (Command.cs - not implemented yet)
* runs setup for central objects
* controls speed and ticks of the game
* runs UpdateTime on DataBank.cs, UpdateBehaviour on AI.cs and UpdateLuck on Fate.cs

AI Engine (AI.cs - nearing completion)
* defines and creates sets of options for each tick of the game
* makes choices for character until it runs out of willpower

Fate Engine (Fate.cs - not implemented yet)
* steers happenings in the game that are outside the 
  direct control of any character

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