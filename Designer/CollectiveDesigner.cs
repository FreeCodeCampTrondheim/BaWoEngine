using System;
using System.Collections.Generic;
using System.Text;





public partial class Designer
{
    public class CollectiveDesigner
    {
        Collective collectiveBeingDesigned;
        Queue<CollectiveAssemblyPattern> assemblyPatterns;
        Queue<ControllingCharacterAssemblyPattern> controllingCharacterAssemblyPatterns;
        Queue<MemberCharacterAssemblyPattern> memberCharacterAssemblyPatterns;

        public void ResetToNewDesign()
        {
            collectiveBeingDesigned = new Collective();
            assemblyPatterns = new Queue<CollectiveAssemblyPattern>();
            controllingCharacterAssemblyPatterns = new Queue<ControllingCharacterAssemblyPattern>();
            memberCharacterAssemblyPatterns = new Queue<MemberCharacterAssemblyPattern>();
        }

        public void AddSituation(Collective.CollectiveSituation situation)
        {
            collectiveBeingDesigned.situations.Add(situation);
        }

        public void AddOption(Collective.CollectiveOption option)
        {
            collectiveBeingDesigned.options.Add(option);
        }

        public void AddForecast(Collective.CollectiveForecast forecast)
        {
            collectiveBeingDesigned.forecasts.Add(forecast);
        }

        public void AddAssemblyPattern(CollectiveAssemblyPattern newPattern)
        {
            assemblyPatterns.Enqueue(newPattern);
        }

        public void AddControllingCharacterAssemblyPattern(ControllingCharacterAssemblyPattern newPattern)
        {
            controllingCharacterAssemblyPatterns.Enqueue(newPattern);
        }

        public void AddMemberCharacterAssemblyPattern(MemberCharacterAssemblyPattern newPattern)
        {
            memberCharacterAssemblyPatterns.Enqueue(newPattern);
        }

        public void AddNewControllingCharacter(int characterID)
        {
            if (!collectiveBeingDesigned.controllingCharacters.Contains(characterID))
                collectiveBeingDesigned.controllingCharacters.Add(characterID);
        }

        public void AddNewMemberCharacter(int characterID)
        {
            if (!collectiveBeingDesigned.memberCharacters.Contains(characterID))
                collectiveBeingDesigned.memberCharacters.Add(characterID);
        }

        public int SendToWorld(int worldNr = 0)
        {
            int id = Generator.GenerateCollectiveFromDesign(
                collectiveBeingDesigned, 
                assemblyPatterns,
                controllingCharacterAssemblyPatterns,
                memberCharacterAssemblyPatterns);

            ResetToNewDesign();
            return id;
        }
    }
}