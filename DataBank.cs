using System;
using System.Collections.Generic;
using System.Text;





// handles storage and access of data throughout game
static class DataBank
{
    public static void UpdateData(DateTime d)
    {
        foreach (var c in characters)
        {
            c.Value.Update(d);
        }

        foreach (var o in organizations)
        {
            o.Value.Update(d);
        }

        foreach (var l in locations)
        {
            l.Value.Update(d);
        }
    }

    public static ulong globalEntityID = 0;

    #region ENTITY RELATIONSHIPS
    float GetChar2CharOpinion(uint fromChar, uint toChar);    // gets one character's opinion of another

    float GetChar2OrgOpinion(uint fromChar, uint toOrg);      // gets one character's opinion of an organization
    float GetOrg2CharOpinion(uint fromOrg, uint toChar);      // gets one organization's opinion of a character

    uint GetChar2OrgInvestment(uint fromChar, uint toOrg);    // gets number of stocks owned in an organization
    #endregion

    #region ATTRIBUTES OF ENTITIES

    float GetCharLuck(int fromChar);

    List<E.Option> GetCharOptions(int fromChar);
    List<E.Situation> GetCharSituations(int fromChar);

    #endregion

    #region CENTRAL ENTITIES
    // key1 = id of entity, value = an entity of undefined type
    public static Dictionary<ulong, E.BaseEntity> entities;

    // key1 = id of character, value = all relationless data about character
    public static Dictionary<ulong, E.Character> characters;

    // key1 = id of organization, value = all relationless data about organization
    public static Dictionary<ulong, E.Organization> organizations;

    // key1 = id of location, value = all relationless data about location
    public static Dictionary<ulong, E.Location> locations;
    #endregion
}