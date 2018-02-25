using System;
using System.Collections.Generic;







public partial class Designer
{
    public class CollectiveAssemblyPattern : IRegisterable
    {
        // use condition method to check for whether you 
        // want the simple entity to be generated or not
        public delegate bool ConditionMethod(Collective c);

        // use special setup method to perform special
        // setup procedures during generation
        public delegate void AdditionalSetupMethod(Collective c);
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

        // category numbers are used to separate characters
        // so as to be able to give them different treatment,
        // and is primarily used during personalization
        public List<int> categoryNumbers = new List<int>();

        // adds a function pointer which runs special
        // generation procedures on character
        public void SetAdditionalSetup(AdditionalSetupMethod method)
        {
            additionalSetupMethod = method;
        }

        public void ExecuteAdditionalSetup(Collective c)
        {
            if (additionalSetupMethod != null) additionalSetupMethod(c);
        }

        #region Adding Situations
        // simple check using chance, with float values
        // from 0 up to and including 1.0
        public void AddSituationByChance(
            CollectiveSituationSharedData situationTemplate,
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
            CollectiveSituationSharedData situationTemplate,
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
            CollectiveOptionSharedData optionTemplate,
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
            CollectiveOptionSharedData optionTemplate,
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
            CollectiveForecastSharedData forecastTemplate,
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
            CollectiveForecastSharedData forecastTemplate,
            ConditionMethod conditionMethod)
        {
            forecastsByMethod.Add(new ForecastByMethod()
            {
                template = forecastTemplate,
                method = conditionMethod
            });
        }
        #endregion

        #region Assemble Semi-Randomized Template Queues
        // gets a set of templates following condition methods that
        // evaluate to true, as well as randomly chosen templates
        public Queue<CollectiveSituationSharedData> PickSituationSharedData(Collective c)
        {
            Queue<CollectiveSituationSharedData> situationSharedData
                    = new Queue<CollectiveSituationSharedData>();

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

        // gets a set of templates following condition methods that
        // evaluate to true, as well as randomly chosen templates
        public Queue<CollectiveOptionSharedData> PickOptionSharedData(Collective c)
        {
            Queue<CollectiveOptionSharedData> optionSharedData
                    = new Queue<CollectiveOptionSharedData>();

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

        // gets a set of templates following condition methods that
        // evaluate to true, as well as randomly chosen templates
        public Queue<CollectiveForecastSharedData> PickForecastSharedData(Collective c)
        {
            Queue<CollectiveForecastSharedData> forecastSharedData
                    = new Queue<CollectiveForecastSharedData>();

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
            public CollectiveSituationSharedData template;
            public double chance;
        }

        public struct SituationByMethod
        {
            public CollectiveSituationSharedData template;
            public ConditionMethod method;
        }

        public struct OptionByChance
        {
            public CollectiveOptionSharedData template;
            public double chance;
        }

        public struct OptionByMethod
        {
            public CollectiveOptionSharedData template;
            public ConditionMethod method;
        }

        public struct ForecastByChance
        {
            public CollectiveForecastSharedData template;
            public double chance;
        }

        public struct ForecastByMethod
        {
            public CollectiveForecastSharedData template;
            public ConditionMethod method;
        }
        #endregion

        public int RegisterAtCatalogue()
        {
            if (!Catalogue.collectiveAssemblyPatterns.Contains(this))
            {
                Catalogue.collectiveAssemblyPatterns.Add(this);
                return Catalogue.collectiveAssemblyPatterns.Count - 1;
            }
            else
            {
                return Catalogue.collectiveAssemblyPatterns.IndexOf(this);
            }
        }
    }
}