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
            Catalogue.CollectiveSituationSharedData situationTemplate,
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
            Catalogue.CollectiveSituationSharedData situationTemplate,
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
            Catalogue.CollectiveOptionSharedData optionTemplate,
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
            Catalogue.CollectiveOptionSharedData optionTemplate,
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
            Catalogue.CollectiveForecastSharedData forecastTemplate,
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
            Catalogue.CollectiveForecastSharedData forecastTemplate,
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
        public Queue<Catalogue.CollectiveSituationSharedData> PickSituationTemplates(Collective c)
        {
            Queue<Catalogue.CollectiveSituationSharedData> situationTemplates
                    = new Queue<Catalogue.CollectiveSituationSharedData>();

            double randomNumber;
            for (int i = 0; i < situationsByChance.Count; i++)
            {
                randomNumber = randomizer.NextDouble();
                if (situationsByChance[i].chance >= randomNumber)
                    situationTemplates.Enqueue(situationsByChance[i].template);
            }

            for (int i = 0; i < situationsByMethod.Count; i++)
            {
                if (situationsByMethod[i].method(c))
                    situationTemplates.Enqueue(situationsByChance[i].template);
            }

            return situationTemplates;
        }

        // gets a set of templates following condition methods that
        // evaluate to true, as well as randomly chosen templates
        public Queue<Catalogue.CollectiveOptionSharedData> PickOptionTemplates(Collective c)
        {
            Queue<Catalogue.CollectiveOptionSharedData> optionTemplates
                    = new Queue<Catalogue.CollectiveOptionSharedData>();

            double randomNumber;
            for (int i = 0; i < optionsByChance.Count; i++)
            {
                randomNumber = randomizer.NextDouble();
                if (optionsByChance[i].chance >= randomNumber)
                    optionTemplates.Enqueue(optionsByChance[i].template);
            }

            for (int i = 0; i < optionsByMethod.Count; i++)
            {
                if (optionsByMethod[i].method(c))
                    optionTemplates.Enqueue(optionsByChance[i].template);
            }

            return optionTemplates;
        }

        // gets a set of templates following condition methods that
        // evaluate to true, as well as randomly chosen templates
        public Queue<Catalogue.CollectiveForecastSharedData> PickForecastTemplates(Collective c)
        {
            Queue<Catalogue.CollectiveForecastSharedData> forecastTemplates
                    = new Queue<Catalogue.CollectiveForecastSharedData>();

            double randomNumber;
            for (int i = 0; i < forecastsByChance.Count; i++)
            {
                randomNumber = randomizer.NextDouble();
                if (forecastsByChance[i].chance >= randomNumber)
                    forecastTemplates.Enqueue(forecastsByChance[i].template);
            }

            for (int i = 0; i < forecastsByMethod.Count; i++)
            {
                if (forecastsByMethod[i].method(c))
                    forecastTemplates.Enqueue(forecastsByChance[i].template);
            }

            return forecastTemplates;
        }
        #endregion

        #region Structs for representing generation by chance and -method
        public struct SituationByChance
        {
            public Catalogue.CollectiveSituationSharedData template;
            public double chance;
        }

        public struct SituationByMethod
        {
            public Catalogue.CollectiveSituationSharedData template;
            public ConditionMethod method;
        }

        public struct OptionByChance
        {
            public Catalogue.CollectiveOptionSharedData template;
            public double chance;
        }

        public struct OptionByMethod
        {
            public Catalogue.CollectiveOptionSharedData template;
            public ConditionMethod method;
        }

        public struct ForecastByChance
        {
            public Catalogue.CollectiveForecastSharedData template;
            public double chance;
        }

        public struct ForecastByMethod
        {
            public Catalogue.CollectiveForecastSharedData template;
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