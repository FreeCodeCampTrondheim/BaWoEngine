# How to write JSON modules
JSON modules is how the engine decides what the background world
will consist of, including how much it will have of it, etc.
The following is description on how to write the 4 required
.JSON files for any module folder loaded into the BaWo engine.

Reading this can be helpful even if you decide to use the
BaWo Module Creator instead once it is up and running.

## Writing module.json file
### Three questions
The module file is the answer to three different questions:
* how does the module affect character generation?  (Generator.cs)
* how should the module generally be represented in data views? (Feeder.cs)
* how should the module react to user actions? (Responder.cs)

#### Generator.cs
Object arrays with specified key-value pairs:
1. startSituations[] -> situationName string -> startLikelihood float
  * start likelihood is value from more than 0.0f to equal or
    less than 1.0f, it represents how likely the situation is
	to be part of a fully generated character
2. startOptions[] -> optionName string -> startLikelihood float
  * same as above but for option
3. startForecasts[] -> forecastName string -> startLikelihood float
  * same as above but for option

#### Feeder.cs - TODO
ff

#### Responder.cs - TODO
ff

##   Writing situations.json file
###  Structure Overview
#### General
Key-value pairs:
1. title string
  * used to identify situation
2. description string
  * used to display information about the situation, any 
    substring of description starting with @ followed by 
    a number is replaced with a string from the index of 
    an *about* array equivalent to the number - the string
    is always an entity's name, and the about array is
    filled during situation personalization in Generator.cs

#### Tags and values
Object arrays with specified key-value pairs:
1. considerations[] -> tag string -> target string -> emphasis int
  * used to make judgement and central in AI.cs, the target 
    string is filled during personalization in Generator.cs
2. textStats[] -> tag string
  * can represent boolean character statistics, the existence
    of the tag equals true, while its absence equals false,
	but counting the number of occurences of the tag can 
	also be useful, though each situation can only grant
	one occurence of the tag
3. integerStats[] -> tag string -> size int
  * represents integer character statistics
4. floatStats[] -> tag string -> size float
  * represents float character statistics

#### Can launch at any tick
Object arrays with specified key-value pairs:
1. launchesSituations[] -> situation string ->
  * textStatRequirements[] ->
    * tag string
  * integerStatRequirements[]
    * tag string -> size int
  * floatStatRequirements[]
    * tag string -> size float
  * entityIndexMap[] -> sourceIndex int, targetIndex int
  * used to refer to situations launched upon certain conditions met,
    each launched situation can have an array of forwarded entity
    references if desired, kind-of like parameters in a constructors,
    defining the new situation as derived from the perished one,
    however any left-out index references are still filled in during
    personalization in Generator.cs
2. launchesOptions[] -> option string ->
  * textStatRequirements[] ->
    * tag string
  * integerStatRequirements[]
    * tag string -> size int
  * floatStatRequirements[]
    * tag string -> size float
  * entityIndexMap[] -> sourceIndex int, targetIndex int
  * used same as above but for options
3. launchesForecasts[] -> forecast string ->
  * textStatRequirements[] ->
    * tag string
  * integerStatRequirements[]
    * tag string -> size int
  * floatStatRequirements[]
    * tag string -> size float
  * entityIndexMap[] -> sourceIndex int, targetIndex int
  * used same as above but for forecasts

### Data and functionality not defined in JSON
1. about[]
  * used to make a situation be about one or entities

## Writing options.json file
###  Structure Overview
#### General
Key-value pairs:
1. title string
  * used to identify option
2. description string
  * used to display information about the situation, any 
    substring of description starting with @ followed by 
    a number is replaced with a string from the index of 
    an *about* array equivalent to the number - the string
    is always an entity's name, and the about array is
    filled during situation personalization in Generator.cs

#### Option Requirements
* baseWillpowerCost int
* considerations[] -> tag string
  * used to calculate final willpower cost

#### Can launch when character chooses option
Object arrays with specified key-value pairs:
1. launchesSituations[] -> situation string ->
  * textStatRequirements[] (optional) ->
    * tag string
  * integerStatRequirements[] (optional) ->
    * tag string -> size int
  * floatStatRequirements[] (optional) ->
    * tag string -> size float
  * entityIndexMap[] (optional) -> sourceIndex int, targetIndex int
  * used to refer to situations launched upon certain conditions met,
    each launched situation can have an array of forwarded entity
    references if desired, kind-of like parameters in a constructors,
    defining the new situation as derived from the perished one,
    however any left-out index references are still filled in during
    personalization in Generator.cs
2. launchesOptions[] -> option string ->
  * textStatRequirements[] (optional) ->
    * tag string
  * integerStatRequirements[] (optional) ->
    * tag string -> size int
  * floatStatRequirements[] (optional) ->
    * tag string -> size float
  * entityIndexMap[] (optional) -> sourceIndex int, targetIndex int
  * used same as above but for options
3. launchesForecasts[] -> forecast string ->
  * textStatRequirements[] (optional) ->
    * tag string
  * integerStatRequirements[] (optional) ->
    * tag string -> size int
  * floatStatRequirements[] (optional) ->
    * tag string -> size float
  * entityIndexMap[] (optional) -> sourceIndex int, targetIndex int
  * used same as above but for forecasts

### Data and functionality not defined in JSON
1. about[]
  * used to make a situation be about one or entities

## Writing forecasts.json file
###  Structure Overview
#### General
Key-value pairs:
1. title string
  * used to identify option
2. description string
  * used to display information about the situation, any 
    substring of description starting with @ followed by 
    a number is replaced with a string from the index of 
    an *about* array equivalent to the number - the string
    is always an entity's name, and the about array is
    filled during situation personalization in Generator.cs

#### Forecast Evaluations
* fortune int
  * whether this represents good fortune (more than 0)
    for the character, or negative fortune (less than 0),
	and if so, by what degree
* chanceOfHappening float
  * how likely this is to play out, represented by
    positive percentage values of 0.0f to 1.0f

#### Can launch when forecast is played out
Object arrays with specified key-value pairs:
1. launchesSituations[] -> situation string ->
  * textStatRequirements[] (optional) ->
    * tag string
  * integerStatRequirements[] (optional) ->
    * tag string -> size int
  * floatStatRequirements[] (optional) ->
    * tag string -> size float
  * entityIndexMap[] (optional) -> sourceIndex int, targetIndex int
  * used to refer to situations launched upon certain conditions met,
    each launched situation can have an array of forwarded entity
    references if desired, kind-of like parameters in a constructors,
    defining the new situation as derived from the perished one,
    however any left-out index references are still filled in during
    personalization in Generator.cs
2. launchesOptions[] -> option string ->
  * textStatRequirements[] (optional) ->
    * tag string
  * integerStatRequirements[] (optional) ->
    * tag string -> size int
  * floatStatRequirements[] (optional) ->
    * tag string -> size float
  * entityIndexMap[] (optional) -> sourceIndex int, targetIndex int
  * used same as above but for options
3. launchesForecasts[] -> forecast string ->
  * textStatRequirements[] (optional) ->
    * tag string
  * integerStatRequirements[] (optional) ->
    * tag string -> size int
  * floatStatRequirements[] (optional) ->
    * tag string -> size float
  * entityIndexMap[] (optional) -> sourceIndex int, targetIndex int
  * used same as above but for forecasts

### Data and functionality not defined in JSON
1. about[]
  * used to make a situation be about one or entities