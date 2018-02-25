using System.Collections.Generic;








public abstract class BaseComplexEntity
{
    // the category numbers describes what categories this complex entity
    // belongs to and is used during personalization
    public List<int> categoryNumbers = new List<int>();

    // use the following to disable and enable
    // complex entity updating, important for
    // 
    public bool runSituations = true;
    public bool runOptions = true;
    public bool runForecasts = true;

    // the way in which a name is constructed from data based on
    // category numbers, which makes it possible to add titles 
    // and other descriptive names, or use various complex entity
    // situations to build something akin to a name or identifier
    public delegate string GetNameMethod(List<int> categoryNumbers);
    public GetNameMethod GetName;
}