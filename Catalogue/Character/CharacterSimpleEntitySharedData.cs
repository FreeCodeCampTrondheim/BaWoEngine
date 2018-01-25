using System;
using System.Text;
using System.Collections.Generic;

public static partial class Catalogue
{
    // Defines shared fields between all character simple templates,
    // like character situations, -options and -forecasts.
    public abstract class CharacterSimpleEntitySharedData : SimpleEntitySharedData
    {
        // use this to control whether the situation, option or
        // forecast should be terminated from the character
        public delegate bool Termination(Character c);
        public Termination ShouldTerminate;

        // use this to control when new situations, options and/or
        // forecasts should be added to the character
        public delegate void Launching(Character c);
        public Launching AttemptLaunching;
    }
}