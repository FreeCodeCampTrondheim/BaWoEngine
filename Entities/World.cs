using System;
using System.Collections.Generic;







public class World
{
    public List<Character> characters;
    public List<Collective> collectives;

    public List<int> GetComplexEntitiesByCategory(
        List<int> requiredNumbers,
        COMPLEX_ENTITY_TYPE type)
    {
        var complexEntitiesOfCategory = new List<int>();

        switch (type)
        {
            case COMPLEX_ENTITY_TYPE.CHARACTER:
                
                for (int i = 0; i < characters.Count; i++)
                {
                    bool numbersMatch = false;
                    for (int j = 0; j < characters[i].categoryNumbers.Count; j++)
                    {
                        for (int k = 0; k < requiredNumbers.Count; k++)
                        {
                            if (characters[i].categoryNumbers.Contains(requiredNumbers[k]))
                            {
                                // add the index of the character
                                complexEntitiesOfCategory.Add(i);
                                numbersMatch = true;
                                break;
                            }
                        }
                        if (numbersMatch)
                        {
                            numbersMatch = false;
                            break;
                        }
                    }
                }
                break;
            case COMPLEX_ENTITY_TYPE.COLLECTIVE:
                for (int i = 0; i < collectives.Count; i++)
                {
                    bool numbersMatch = false;
                    for (int j = 0; j < collectives[i].categoryNumbers.Count; j++)
                    {
                        for (int k = 0; k < requiredNumbers.Count; k++)
                        {
                            if (collectives[i].categoryNumbers.Contains(requiredNumbers[k]))
                            {
                                // add the index of the collective
                                complexEntitiesOfCategory.Add(i);
                                numbersMatch = true;
                                break;
                            }
                        }
                        if (numbersMatch)
                        {
                            numbersMatch = false;
                            break;
                        }
                    }
                }
                break;
            default:
                throw new Exception("Type neither character nor collective");
        }

        return complexEntitiesOfCategory;
    }
}