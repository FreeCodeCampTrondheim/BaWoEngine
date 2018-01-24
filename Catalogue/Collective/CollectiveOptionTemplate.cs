﻿using System;
using System.Collections.Generic;
using System.Text;

public static partial class Catalogue
{
    // A unit for representing something that the collective can choose to do,
    // granted that the characters who steer the collective support the option.
    public class CollectiveOptionTemplate : CollectiveSimpleEntityTemplate
    {
        // the two character options used to represent the collective option
        // at individual controlling characters, and which is used to measure
        // consensus among characters controlling the collective
        public CharacterOptionTemplate approvalOption;
        public CharacterOptionTemplate rejectionOption;
    }
}