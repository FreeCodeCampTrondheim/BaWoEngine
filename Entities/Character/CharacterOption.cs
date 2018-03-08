using System;
using System.Collections.Generic;







public partial class Character
{
    public class CharacterOption : BaseSimpleEntity, IShareData<CharacterOptionSharedData>
    {
        public CharacterOptionSharedData sharedData { get; set; }

        // key = target id, double = sum care about degree
        Dictionary<int, double> targetValues = new Dictionary<int, double>();

        public int currentAim;
        public double currentAimValue;

        public void AddTargetValues(
            List<CareAbout> careAbouts,
            List<int> careAboutTargets)
        {
            for (int i = 0; i < careAbouts.Count; i++)
            {
                if (targetValues.ContainsKey(careAboutTargets[i]))
                    targetValues[careAboutTargets[i]] += careAbouts[i].degree;
                else targetValues.Add(careAboutTargets[i], careAbouts[i].degree);
            }
        }

        public void RemoveTargetValues(
            List<CareAbout> careAbouts,
            List<int> careAboutTargets)
        {
            for (int i = 0; i < careAbouts.Count; i++)
            {
                if (targetValues.ContainsKey(careAboutTargets[i]))
                    targetValues[careAboutTargets[i]] -= careAbouts[i].degree;
            }
        }
        
        public void FindNewAim()
        {
            foreach (var item in targetValues)
            {
                if (item.Value > currentAimValue)
                {
                    currentAimValue = item.Value;
                    currentAim = item.Key;
                }
            }
        }
    }
}