using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;




public partial class Collective
{
    public class CollectiveOption
    {
        public Catalogue.CollectiveOptionTemplate template;

        // the id of the individual member characters that
        // are affected by what happens within the collective
        List<int> memberCharacters;

        // the id of the individual characters
        // that make decisions for the collective
        List<int> controllingCharacters;
    }
}