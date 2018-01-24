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
        SpecialSetupMethod specialSetupMethod = null;

        #region Pattern Queues
        public Queue<SituationByChance> situationsByChance = new Queue<SituationByChance>();
        public Queue<SituationByMethod> situationsByMethod = new Queue<SituationByMethod>();

        public Queue<OptionByChance> optionsByChance = new Queue<OptionByChance>();
        public Queue<OptionByMethod> optionsByMethod = new Queue<OptionByMethod>();

        public Queue<ForecastByChance> forecastsByChance = new Queue<ForecastByChance>();
        public Queue<ForecastByMethod> forecastsByMethod = new Queue<ForecastByMethod>();
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
            situationsByChance.Enqueue(new SituationByChance()
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
            situationsByMethod.Enqueue(new SituationByMethod()
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
            optionsByChance.Enqueue(new OptionByChance()
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
            optionsByMethod.Enqueue(new OptionByMethod()
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
            forecastsByChance.Enqueue(new ForecastByChance()
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
            forecastsByMethod.Enqueue(new ForecastByMethod()
            {
                template = forecastTemplate,
                method = conditionMethod
            });
        }
        #endregion
        
        #region Structs for representing ByChance and ByMethod
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