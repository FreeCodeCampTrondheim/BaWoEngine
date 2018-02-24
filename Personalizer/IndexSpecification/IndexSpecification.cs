using System.Collections.Generic;








public class IndexSpecification
{
    // at what stage of index filling the process should start
    public INDEX_FILL_TYPE fillType;

    // where to look for the complex entity
    public COMPLEX_ENTITY_TYPE targetType;

    // which care abouts to limit the measurement to
    public List<int> careAboutGroupIDs;

    // which complex entities to limit the randomization to
    public List<int> categoryNumbers;
}