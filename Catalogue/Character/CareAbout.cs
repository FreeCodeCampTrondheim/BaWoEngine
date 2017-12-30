using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

static partial class Catalogue
{
    // A unit representing a source of care directed at some entity. The emphasis
    // of the care measures the degree of love or hate that the source represents,
    // with positive for love and negative for hate. The title or name given to the
    // source, i.e. "Shares Room", "Is Married", "Employed" etc. is specified at
    // associated collection.
    public struct CareAbout
    {
        // what character- or collective template is referenced in entity target ID
        public string targetType;

        // the index to look up at in the Data Bank
        public uint entityTargetID;

        // represents the size of the care, with positive for love and negative for hate
        public int emphasis;
    }
}