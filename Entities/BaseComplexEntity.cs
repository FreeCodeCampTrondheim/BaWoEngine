








public abstract class BaseComplexEntity
{
    // the personalization numbers identifies if the complex entity 
    // can be added as a reference during personalization
    public int[] personalizationNumbers;

    public Catalogue.StatGroup stats;

    // use the following to disable and enable
    // complex entity updating
    public bool runSituations = true;
    public bool runOptions = true;
    public bool runForecasts = true;
}