using System.Collections.Generic;







// use this to communicate player actions to the BaWo world
public static class Responder
{
    #region Response
    public static Dictionary<string, ResponseTemplate> responseTemplates
        = new Dictionary<string, ResponseTemplate>();

    public struct Response
    {
        ResponseTemplate responseTemplate;

        public void SetSituationAboutIndices(string situation, List<uint> indices)
        {
            responseTemplate.triggersSituations[situation].aboutIndices = indices;
        }

        public void SetOptionAboutIndices(string option, List<uint> indices)
        {
            responseTemplate.triggersOptions[option].aboutIndices = indices;
        }

        public void SetForecastAboutIndices(string forecast, List<uint> indices)
        {
            responseTemplate.triggersForecasts[forecast].aboutIndices = indices;
        }
    }

    public class ResponseTemplate
    {
        public Dictionary<string, TriggerRequirements> triggersSituations;
        public Dictionary<string, TriggerRequirements> triggersOptions;
        public Dictionary<string, TriggerRequirements> triggersForecasts;
    }

    public class TriggerRequirements
    {
        public List<string> textStatRequirements;
        public Dictionary<string, int> intStatRequirements;
        public Dictionary<string, float> floatStatRequirements;

        public List<uint> aboutIndices;
    }
    #endregion

    public static void ReactAtPlayer(string response, uint characterIndex)
    {

    }

    public static void ReactAtCharacter(string response, uint characterIndex)
    {

    }

    public static void ReactAtOrganization(string response, uint characterIndex)
    {

    }

    public static void ReactAtLocation(string response, uint characterIndex)
    {

    }
}