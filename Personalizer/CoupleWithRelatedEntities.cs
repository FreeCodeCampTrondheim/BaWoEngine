using System.Collections.Generic;
using System.Linq;







public static partial class Personalizer
{
    public static void AddIndicesByStrongestRelationships(
        BaseSimpleEntity simpleEntity,
        SimpleEntitySharedData sharedData,
        Character c)
    {
        Queue<int> characters = GetMostEmphasizedCharacters(c);
        Queue<int> collectives = GetMostEmphasizedCollectives(c);

        int len = simpleEntity.about.Length;
        for (int i = 0; i < len; i++)
        {
            if (sharedData.aboutTypes[i] == COMPLEX_ENTITY_TYPE.CHARACTER && characters.Count > 0)
                simpleEntity.about[i] = characters.Dequeue();
            else if(collectives.Count > 0)
                simpleEntity.about[i] = collectives.Dequeue();
        }
    }

    static Queue<int> GetMostEmphasizedCharacters(Character c)
    {
        Queue<int> mostEmphasized =
            new Queue<int>();

        Dictionary<int, double> entities = new Dictionary<int, double>();
        foreach (List<CareAbout> temp in c.caresAbout.Values)
        {
            List<CareAbout> copyList = new List<CareAbout>(temp);

            int len = copyList.Count;
            for (int i = 0; i < len; i++)
            {
                if (copyList[i].targetType == COMPLEX_ENTITY_TYPE.CHARACTER)
                {
                    if (entities.ContainsKey(copyList[i].targetID))
                        entities.Add(copyList[i].targetID, copyList[i].emphasis);
                    else entities[copyList[i].targetID] += copyList[i].emphasis;
                }
            }
        }

        var sum = entities.AsQueryable().OrderByDescending(item => item.Value).ToArray();

        int len2 = sum.Length;
        for (int i = 0; i < len2; i++)
        {
            mostEmphasized.Enqueue(sum[i].Key);
        }

        return mostEmphasized;
    }

    static Queue<int> GetMostEmphasizedCollectives(Character c)
    {
        Queue<int> mostEmphasized =
            new Queue<int>();

        Dictionary<int, double> entities = new Dictionary<int, double>();
        foreach (List<CareAbout> temp in c.caresAbout.Values)
        {
            List<CareAbout> copyList = new List<CareAbout>(temp);

            int len = copyList.Count;
            for (int i = 0; i < len; i++)
            {
                if (copyList[i].targetType == COMPLEX_ENTITY_TYPE.COLLECTIVE)
                {
                    if (entities.ContainsKey(copyList[i].targetID))
                        entities.Add(copyList[i].targetID, copyList[i].emphasis);
                    else entities[copyList[i].targetID] += copyList[i].emphasis;
                }
            }
        }

        var sum = entities.AsQueryable().OrderByDescending(item => item.Value).ToArray();

        int len2 = sum.Length;
        for (int i = 0; i < len2; i++)
        {
            mostEmphasized.Enqueue(sum[i].Key);
        }

        return mostEmphasized;
    }
}