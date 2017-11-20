    ARCHITECTURAL DESCRIPTION:
    
    Game Manager
    - instantiates central objects
    - controls speed and ticks of the game
    - runs UpdateBehaviour on AI, and UpdateData on Data Bank

    AI Engines
    - define and create a set of options for each tick of the game 
    - chooses an option at a time, but makes a variable amount of 
      choices after each other

    Entities
    - define non-relational data about in-game entities

    Data Bank
    - define relational data
    - stores all data and gives easy access to it, 
      either directly or for iteration
    
    Player
    - defines all possible responses to user actions, like retrieving data and applying choices
    - defines all automated tasks done for the user
    - includes searching, various information feeds, character creation, user choices and so forth

	
	MENTAL NOTES:
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
		- nature options, what options nature has, it chooses based on:
			- base likelihood weight
			- aggragate likelihood weight from pairing "aggregation tags" of option with "aggregatable tags" of situations


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