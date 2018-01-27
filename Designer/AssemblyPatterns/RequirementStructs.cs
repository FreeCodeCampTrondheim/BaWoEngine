using System;
using System.Collections.Generic;
using System.Text;






public partial class Designer
{
    #region Structs for value requirements
    struct NumberRequirement
    {
        public int statID;
        public double value;
        public NUMBER_REQUIREMENT_TYPE requirementType;
    }

    struct TextRequirement
    {
        public int statID;
        public int value;
        public TEXT_REQUIREMENT_TYPE requirementType;
    }

    struct BoolRequirement
    {
        public int statID;
        public bool value;
    }
    #endregion
}