using System.Text;








public abstract class BaseComplexEntity
{
    // the personalization numbers identifies if the complex entity 
    // can be added as a reference during personalization
    public int[] personalizationNumbers;

    // which text stats (indicated by integer title id) to use
    // for displaying name of complex entity
    public int[] nameTextStats;

    // compiles the full name of the complex entity
    public string GetName()
    {
        StringBuilder builder = new StringBuilder();

        for (int i = 0; i < nameTextStats.Length; i++)
        {
            int textID = stats.textStats[nameTextStats[i]];
            builder.Append(Catalogue.textEnums[textID]);

            if (i < nameTextStats.Length - 1) builder.Append(" ");
        }

        return builder.ToString();
    }

    public StatGroup stats;

    // use the following to disable and enable
    // complex entity updating
    public bool runSituations = true;
    public bool runOptions = true;
    public bool runForecasts = true;
}