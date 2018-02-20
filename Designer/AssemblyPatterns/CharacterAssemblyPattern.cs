using System;
using System.Collections.Generic;







public partial class Designer
{
    public class CharacterAssemblyPattern : IRegisterable
    {
        // use condition method to check for whether you
        // want the simple entity to be generated or not
        public delegate bool ConditionMethod(Character c);

        // use special setup method to perform special
        // setup procedures during generation
        public delegate void AdditionalSetupMethod(Character c);
        AdditionalSetupMethod additionalSetupMethod = null;

        // random number engine
        Random randomizer = new Random();

        #region Pattern Queues
        List<SituationByChance> situationsByChance = new List<SituationByChance>();
        List<SituationByMethod> situationsByMethod = new List<SituationByMethod>();

        List<OptionByChance> optionsByChance = new List<OptionByChance>();
        List<OptionByMethod> optionsByMethod = new List<OptionByMethod>();

        List<ForecastByChance> forecastsByChance = new List<ForecastByChance>();
        List<ForecastByMethod> forecastsByMethod = new List<ForecastByMethod>();
        #endregion

        // adds a function pointer which runs special
        // generation procedures on character
        public void SetAdditionalSetup(AdditionalSetupMethod method)
        {
            additionalSetupMethod = method;
        }

        public void ExecuteAdditionalSetup(Character c)
        {
            if (additionalSetupMethod != null) additionalSetupMethod(c);
        }

        #region Adding Situations
        // simple check using chance, with float values
        // from 0 up to and including 1.0
        public void AddSituationByChance(
            CharacterSituationSharedData situationSharedData,
            float percentageChance)
        {
            situationsByChance.Add(new SituationByChance()
            {
                template = situationSharedData,
                chance = percentageChance
            });
        }

        // runs method to see if simple entity should be added
        public void AddSituationByConditionMethod(
            CharacterSituationSharedData situationSharedData,
            ConditionMethod conditionMethod)
        {
            situationsByMethod.Add(new SituationByMethod()
            {
                template = situationSharedData,
                method = conditionMethod
            });
        }
        #endregion

        #region Adding Options
        // simple check using chance, with float values
        // from 0 up to and including 1.0
        public void AddOptionByChance(
            CharacterOptionSharedData optionSharedData,
            float percentageChance)
        {
            optionsByChance.Add(new OptionByChance()
            {
                template = optionSharedData,
                chance = percentageChance
            });
        }

        // runs method to see if simple entity should be added
        public void AddOptionByConditionMethod(
            CharacterOptionSharedData optionSharedData,
            ConditionMethod conditionMethod)
        {
            optionsByMethod.Add(new OptionByMethod()
            {
                template = optionSharedData,
                method = conditionMethod
            });
        }
        #endregion

        #region Adding Forecasts
        // simple check using chance, with float values
        // from 0 up to and including 1.0
        public void AddForecastByChance(
            CharacterForecastSharedData forecastSharedData,
            float percentageChance)
        {
            forecastsByChance.Add(new ForecastByChance()
            {
                template = forecastSharedData,
                chance = percentageChance
            });
        }

        // runs method to see if simple entity should be added
        public void AddForecastByConditionMethod(
            CharacterForecastSharedData forecastSharedData,
            ConditionMethod conditionMethod)
        {
            forecastsByMethod.Add(new ForecastByMethod()
            {
                template = forecastSharedData,
                method = conditionMethod
            });
        }
        #endregion

        #region Assemble Semi-Randomized Shared Data Queues
        // gets a set of shared data based on whether some condition methods
        // evaluate to true or false, as well as randomly chosen shared data
        public Queue<CharacterSituationSharedData> PickSituationSharedData(Character c)
        {
            Queue<CharacterSituationSharedData> situationSharedData
                    = new Queue<CharacterSituationSharedData>();

            double randomNumber;
            for (int i = 0; i < situationsByChance.Count; i++)
            {
                randomNumber = randomizer.NextDouble();
                if (situationsByChance[i].chance >= randomNumber)
                    situationSharedData.Enqueue(situationsByChance[i].template);
            }

            for (int i = 0; i < situationsByMethod.Count; i++)
            {
                if (situationsByMethod[i].method(c))
                    situationSharedData.Enqueue(situationsByChance[i].template);
            }

            return situationSharedData;
        }

        // gets a set of shared data based on whether some condition methods
        // evaluate to true or false, as well as randomly chosen shared data
        public Queue<CharacterOptionSharedData> PickOptionSharedData(Character c)
        {
            Queue<CharacterOptionSharedData> optionSharedData
                    = new Queue<CharacterOptionSharedData>();

            double randomNumber;
            for (int i = 0; i < optionsByChance.Count; i++)
            {
                randomNumber = randomizer.NextDouble();
                if (optionsByChance[i].chance >= randomNumber)
                    optionSharedData.Enqueue(optionsByChance[i].template);
            }

            for (int i = 0; i < optionsByMethod.Count; i++)
            {
                if (optionsByMethod[i].method(c))
                    optionSharedData.Enqueue(optionsByChance[i].template);
            }

            return optionSharedData;
        }

        // gets a set of shared data based on whether some condition methods
        // evaluate to true or false, as well as randomly chosen shared data
        public Queue<CharacterForecastSharedData> PickForecastSharedData(Character c)
        {
            Queue<CharacterForecastSharedData> forecastSharedData
                    = new Queue<CharacterForecastSharedData>();

            double randomNumber;
            for (int i = 0; i < forecastsByChance.Count; i++)
            {
                randomNumber = randomizer.NextDouble();
                if (forecastsByChance[i].chance >= randomNumber)
                    forecastSharedData.Enqueue(forecastsByChance[i].template);
            }

            for (int i = 0; i < forecastsByMethod.Count; i++)
            {
                if (forecastsByMethod[i].method(c))
                    forecastSharedData.Enqueue(forecastsByChance[i].template);
            }

            return forecastSharedData;
        }
        #endregion

        #region Structs for representing generation by chance and -method
        public struct SituationByChance
        {
            public CharacterSituationSharedData template;
            public double chance;
        }

        public struct SituationByMethod
        {
            public CharacterSituationSharedData template;
            public ConditionMethod method;
        }

        public struct OptionByChance
        {
            public CharacterOptionSharedData template;
            public double chance;
        }

        public struct OptionByMethod
        {
            public CharacterOptionSharedData template;
            public ConditionMethod method;
        }

        public struct ForecastByChance
        {
            public CharacterForecastSharedData template;
            public double chance;
        }

        public struct ForecastByMethod
        {
            public CharacterForecastSharedData template;
            public ConditionMethod method;
        }
        #endregion

        public int RegisterAtCatalogue()
        {
            if (!Catalogue.characterAssemblyPatterns.Contains(this))
            {
                Catalogue.characterAssemblyPatterns.Add(this);
                return Catalogue.characterAssemblyPatterns.Count - 1;
            }
            else
            {
                return Catalogue.characterAssemblyPatterns.IndexOf(this);
            }
        }
    }
}