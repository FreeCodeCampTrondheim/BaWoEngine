using System;
using System.Collections.Generic;
using System.Text;

public static partial class Catalogue
{
    // A unit for representing something that the collective can choose to do,
    // granted that the characters who steer the collective support the option.
    public class CollectiveOptionTemplate : CollectiveSimpleEntityTemplate
    {
        // the two character options used to represent the collective option
        // at individual controlling characters, and which is used to measure
        // consensus among characters controlling the collective
        public CharacterOptionTemplate approvalOption
        {
            get;
            private set;
        }
        public CharacterOptionTemplate rejectionOption
        {
            get;
            private set;
        }

        // the character option is represented as the same as the
        // collective option except with regards to base willpower
        // cost and relevant cares and motivators that define
        // character behaviour with regards to the collective option
        public void InitializeCharacterOptions(
            uint INIT_baseWillpowerCost, 
            List<string> INIT_approvalCaresAndMotivators,
            List<string> INIT_rejectionCaresAndMotivators)
        {
            approvalOption.title = "Approve " + title;
            rejectionOption.title = "Reject " + title;

            approvalOption.description = description;
            rejectionOption.description = description;
            
            approvalOption.baseWillpowerCost = INIT_baseWillpowerCost;
            rejectionOption.baseWillpowerCost = INIT_baseWillpowerCost;

            approvalOption.relevantCaresAndMotivators = INIT_approvalCaresAndMotivators;
            rejectionOption.relevantCaresAndMotivators = INIT_rejectionCaresAndMotivators;

            // removes options if one has already been chosen
            approvalOption.ShouldTerminate = c =>
            {
                return (c.stats.boolStats.Contains("Has approved " + title));
            };
            rejectionOption.ShouldTerminate = c =>
            {
                return (c.stats.boolStats.Contains("Has rejected " + title));
            };

            // marks the option as chosen
            approvalOption.AttemptLaunching = c =>
            {
                c.stats.boolStats.Add("Has approved " + title);
                c.stats.boolStats.Remove("Has rejected " + title);
            };
            rejectionOption.AttemptLaunching = c =>
            {
                c.stats.boolStats.Add("Has rejected " + title);
                c.stats.boolStats.Remove("Has approved " + title);
            };
        }
    }
}