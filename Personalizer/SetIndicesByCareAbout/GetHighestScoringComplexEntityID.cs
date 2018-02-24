using System.Collections.Generic;
using System.Linq;







public static partial class Personalizer
{
    // finds and retrieves the complex entity with
    // the highest combined degree of CareAbout
    static int GetHighestScoringComplexEntityID(List<CareAbout> ca)
    {
        // integer is ID of complex entity, double is score sum
        var results = new Dictionary<int, double>();

        // sum up degrees for each complex entity
        for (int i = 0; i < ca.Count; i++)
        {
            if (results.ContainsKey(ca[i].targetAboutIndex))
                results[ca[i].targetAboutIndex] += ca[i].degree;
            else results.Add(ca[i].targetAboutIndex, ca[i].degree);
        }

        // finds largest value, then searches for corresponding index
        double maxVal = results.Values.Max();
        int id = results.FirstOrDefault(pair => 
        {
            return pair.Value == maxVal;
        }).Key;

        return id;
    }
}