﻿








// Defines shared fields and methods between all collective simple
// templates, like collective situations, -options and -forecasts.
public abstract class CollectiveSimpleEntitySharedData : SimpleEntitySharedData
{
    // use this to control whether the situation, option or
    // forecast should be terminated from the collective,
    // the return-value determines this
    public delegate bool Termination(Collective c);
    public Termination ShouldTerminate;

    // use this to control whether new situations, options and/or
    // forecasts should be added to the collective
    public delegate void Launching(Collective c);
    public Launching AttemptLaunching;

    // use this to control whether new situations, options and/or
    // forecasts should be added to characters within the collective
    public delegate void Spreading(Collective c);
    public Spreading AttemptSpreading;
}