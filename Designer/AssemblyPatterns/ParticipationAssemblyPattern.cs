using System.Collections.Generic;








public partial class Designer
{
    public class ParticipationAssemblyPattern
    {
        // use condition method to check for whether you 
        // want the character to be added or not
        public delegate bool ConditionMethod(Character potentialCharacter, Collective targetCollective);

        // use special setup method to perform special
        // setup procedures during generation
        public delegate void AdditionalSetupMethod(Collective c);
        AdditionalSetupMethod additionalSetupMethod = null;

        Queue<ConditionMethod> conditionMethods =
            new Queue<ConditionMethod>();

        Queue<NumberRequirement> numberRequirements =
            new Queue<NumberRequirement>();
        Queue<TextRequirement> textRequirements =
            new Queue<TextRequirement>();
        Queue<BoolRequirement> boolRequirements =
            new Queue<BoolRequirement>();

        // adds a function pointer which runs special
        // participation registration procedures on collective
        public void SetAdditionalSetup(AdditionalSetupMethod method)
        {
            additionalSetupMethod = method;
        }

        public void ExecuteAdditionalSetup(Collective c)
        {
            if (additionalSetupMethod != null) additionalSetupMethod(c);
        }

        // if method evaluates to true, character is added
        public void AddCharacterByMethod(ConditionMethod method)
        {
            conditionMethods.Enqueue(method);
        }

        public void AddNumberRequirement(int numberStatID, double requiredValue, NUMBER_REQUIREMENT_TYPE numberRequirementType)
        {
            numberRequirements.Enqueue(new NumberRequirement
            {
                statID = numberStatID,
                value = requiredValue,
                requirementType = numberRequirementType
            });
        }

        public void AddTextRequirement(int textStatID, int requiredValue, TEXT_REQUIREMENT_TYPE textRequirementType)
        {
            textRequirements.Enqueue(new TextRequirement
            {
                statID = textStatID,
                value = requiredValue,
                requirementType = textRequirementType
            });
        }

        public void AddBoolRequirement(int boolStatID, bool requiredValue)
        {
            boolRequirements.Enqueue(new BoolRequirement
            {
                statID = boolStatID,
                value = requiredValue
            });
        }

        public enum REGISTER_PATTERN_AS
        {
            CONTROLLING_CHARACTER,
            MEMBER_CHARACTER
        }

        public int RegisterAtCatalogue(REGISTER_PATTERN_AS whereToRegister)
        {
            if (whereToRegister == REGISTER_PATTERN_AS.CONTROLLING_CHARACTER)
            {
                if (!Catalogue.controllingCharacterAssemblyPatterns.Contains(this))
                {
                    Catalogue.controllingCharacterAssemblyPatterns.Add(this);
                    return Catalogue.controllingCharacterAssemblyPatterns.Count - 1;
                }
                else
                {
                    return Catalogue.controllingCharacterAssemblyPatterns.IndexOf(this);
                }
            }

            else if (whereToRegister == REGISTER_PATTERN_AS.MEMBER_CHARACTER)
            {
                if (!Catalogue.memberCharacterAssemblyPatterns.Contains(this))
                {
                    Catalogue.memberCharacterAssemblyPatterns.Add(this);
                    return Catalogue.memberCharacterAssemblyPatterns.Count - 1;
                }
                else
                {
                    return Catalogue.memberCharacterAssemblyPatterns.IndexOf(this);
                }
            }

            else
            {
                return -1;
            }
        }
    }
}