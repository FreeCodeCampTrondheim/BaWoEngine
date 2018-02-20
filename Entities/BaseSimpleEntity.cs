using System.Collections.Generic;
using System.Text;







public abstract class BaseSimpleEntity
{
    // which complex entity is responsible for launching
    // this situation/option/forecast upon the complex
    // entity where this simple entity resides
    public int sourceEntityID;

    // the type of complex entity that the source
    // entity id refers to
    public COMPLEX_ENTITY_TYPE sourceEntityType;

    // which complex entities this option will affect
    public int[] targetEntityID;

    // the type of complex entities that the target
    // entity IDs refers to
    public COMPLEX_ENTITY_TYPE[] targetEntityType;

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
                BaseComplexEntity entity = (sharedData.aboutIndexFilling[i] == COMPLEX_ENTITY_TYPE.CHARACTER) ?
                    entity = Command.worlds[worldID].characters[about[i]] :
                    entity = Command.worlds[worldID].collectives[about[i]];

                builder.Append(entity.GetName());
            }

            return builder.ToString();
        }

        else return sharedData.description;
    }

    // references to entities in description
    public int[] about;
}