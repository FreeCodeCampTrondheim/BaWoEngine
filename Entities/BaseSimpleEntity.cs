using System.Text;
using System.Collections.Generic;







public abstract class BaseSimpleEntity
{
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
                BaseComplexEntity entity = (sharedData.aboutSpecs[i].targetType == COMPLEX_ENTITY_TYPE.CHARACTER) ?
                    entity = Command.worlds[worldID].characters[about[i]] :
                    entity = Command.worlds[worldID].collectives[about[i]];

                builder.Append(entity.GetName(entity.categoryNumbers));
            }

            return builder.ToString();
        }

        else return sharedData.description;
    }

    // references to entities in description
    public List<int> about;
}