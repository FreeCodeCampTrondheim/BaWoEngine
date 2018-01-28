using System.Collections.Generic;
using System.Text;







public abstract class BaseSimpleEntity
{
    // which entity is responsible for launching this
    // situation/option/forecast, the target being the 
    // entity where this simple entity is listed
    public int sourceEntityID;

    // whether the source is a collective instead of a character
    public bool sourceIsCollective = false;

    // compiles a description with the full names of all referenced entities
    public string GetDescription(int worldID, SimpleEntitySharedData sharedData)
    {
        if (sharedData.description.Contains("@"))
        {
            string[] descriptionParts = sharedData.description.Split('@');
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < descriptionParts.Length; i++)
            {
                builder.Append(descriptionParts[i]);

                // if it's not of type character, then collective is assumed
                BaseComplexEntity entity = (aboutTypes[i] == COMPLEX_ENTITY_TYPE.CHARACTER) ?
                    entity = Command.worlds[worldID].characters[about[i]] :
                    entity = Command.worlds[worldID].collectives[about[i]];

                builder.Append(entity.GetName());
            }

            return builder.ToString();
        }

        else return sharedData.description;
    }

    // what type of complex entity each "@" references, with direct mapping from
    // list index to the first-to-last order of "@" occurences in description
    public List<COMPLEX_ENTITY_TYPE> aboutTypes;

    // references to entities in description
    public int[] about;
}