








// A unit for representing something that can happen to the characters 
// that are part of the collective, but which the controlling characters
// have no immediate control over - ergo "fate".
public class CollectiveForecastSharedData : CollectiveSimpleEntitySharedData
{
    // Whether this represents positive fortune (0 or above)
    // for the collective, or negative fortune (below 0).
    public int fortune;

    // The base chance that this will happen relative to other forecasts,
    // represented as a percentage value from 0 up to and including 1.
    // Internally within the fate engine, the real chance is methodologically
    // skewed in favour of smaller positive or negative fortunes, due to a
    // need for filling "fortune quotas".
    public float baseChance;
}