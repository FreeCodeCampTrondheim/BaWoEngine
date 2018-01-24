using System;
using System.Collections.Generic;
using System.Text;






namespace AssemblyPattern
{
    public class Character
    {
        // use condition method to check for whether you 
        // want the simple entity to be generated or not
        public delegate bool ConditionMethod(Character c);

        // use special setup method to perform special
        // setup procedures during generation
        public delegate void SpecialSetupMethod(Character c);
        public SpecialSetupMethod specialSetupMethod = null;

        #region Pattern Queues
        public List<SituationByChance> situationsByChance = new List<SituationByChance>();
        public List<SituationByMethod> situationsByMethod = new List<SituationByMethod>();

        public List<OptionByChance> optionsByChance = new List<OptionByChance>();
        public List<OptionByMethod> optionsByMethod = new List<OptionByMethod>();

        public List<ForecastByChance> forecastsByChance = new List<ForecastByChance>();
        public List<ForecastByMethod> forecastsByMethod = new List<ForecastByMethod>();
        #endregion

        // adds a function pointer which runs special
        // generation procedures on character
        public void SetSpecialSetupMethod(SpecialSetupMethod method)
        {
            specialSetupMethod = method;
        }

        #region Adding Situations
        // simple check using chance, with float values
        // from 0 up to and including 1.0
        public void AddSituationByChance(
            Catalogue.CharacterSituationTemplate situationTemplate,
            float percentageChance)
        {
            situationsByChance.Add(new SituationByChance()
            {
                template = situationTemplate,
                chance = percentageChance
            });
        }

        // runs method to see if simple entity should be added
        public void AddSituationByConditionMethod(
            Catalogue.CharacterSituationTemplate situationTemplate,
            ConditionMethod conditionMethod)
        {
            situationsByMethod.Add(new SituationByMethod()
            {
                template = situationTemplate,
                method = conditionMethod
            });
        }
        #endregion

        #region Adding Options
        // simple check using chance, with float values
        // from 0 up to and including 1.0
        public void AddOptionByChance(
            Catalogue.CharacterOptionTemplate optionTemplate,
            float percentageChance)
        {
            optionsByChance.Add(new OptionByChance()
            {
                template = optionTemplate,
                chance = percentageChance
            });
        }

        // runs method to see if simple entity should be added
        public void AddOptionByConditionMethod(
            Catalogue.CharacterOptionTemplate optionTemplate,
            ConditionMethod conditionMethod)
        {
            optionsByMethod.Add(new OptionByMethod()
            {
                template = optionTemplate,
                method = conditionMethod
            });
        }
        #endregion

        #region Adding Forecasts
        // simple check using chance, with float values
        // from 0 up to and including 1.0
        public void AddForecastByChance(
            Catalogue.CharacterForecastTemplate forecastTemplate,
            float percentageChance)
        {
            forecastsByChance.Add(new ForecastByChance()
            {
                template = forecastTemplate,
                chance = percentageChance
            });
        }

        // runs method to see if simple entity should be added
        public void AddForecastByConditionMethod(
            Catalogue.CharacterForecastTemplate forecastTemplate,
            ConditionMethod conditionMethod)
        {
            forecastsByMethod.Add(new ForecastByMethod()
            {
                template = forecastTemplate,
                method = conditionMethod
            });
        }
        #endregion
        
        #region Structs for representing generation by chance and -method
        public struct SituationByChance
        {
            public Catalogue.CharacterSituationTemplate template;
            public float chance;
        }

        public struct SituationByMethod
        {
            public Catalogue.CharacterSituationTemplate template;
            public ConditionMethod method;
        }

        public struct OptionByChance
        {
            public Catalogue.CharacterOptionTemplate template;
            public float chance;
        }

        public struct OptionByMethod
        {
            public Catalogue.CharacterOptionTemplate template;
            public ConditionMethod method;
        }

        public struct ForecastByChance
        {
            public Catalogue.CharacterForecastTemplate template;
            public float chance;
        }

        public struct ForecastByMethod
        {
            public Catalogue.CharacterForecastTemplate template;
            public ConditionMethod method;
        }
        #endregion
    }
}