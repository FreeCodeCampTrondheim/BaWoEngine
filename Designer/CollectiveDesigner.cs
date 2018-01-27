using System;
using System.Collections.Generic;
using System.Text;





public partial class Designer
{
    public static class CollectiveDesigner
    {
        static Collective collectiveBeingDesigned;
        static Queue<CollectiveAssemblyPattern> assemblyPatterns;
        static Queue<ParticipationAssemblyPattern> controllingCharacterAssemblyPatterns;
        static Queue<ParticipationAssemblyPattern> memberCharacterAssemblyPatterns;

        public static void ResetToNewDesign()
        {
            collectiveBeingDesigned = new Collective();
            assemblyPatterns = new Queue<CollectiveAssemblyPattern>();
            controllingCharacterAssemblyPatterns = new Queue<ParticipationAssemblyPattern>();
            memberCharacterAssemblyPatterns = new Queue<ParticipationAssemblyPattern>();
        }

        public static void AddSituation(Collective.CollectiveSituation situation)
        {
            collectiveBeingDesigned.situations.Add(situation);
        }

        public static void AddOption(Collective.CollectiveOption option)
        {
            collectiveBeingDesigned.options.Add(option);
        }

        public static void AddForecast(Collective.CollectiveForecast forecast)
        {
            collectiveBeingDesigned.forecasts.Add(forecast);
        }

        public static void AddAssemblyPattern(CollectiveAssemblyPattern newPattern)
        {
            assemblyPatterns.Enqueue(newPattern);
        }

        public static void AddControllingCharacterAssemblyPattern(ParticipationAssemblyPattern newPattern)
        {
            controllingCharacterAssemblyPatterns.Enqueue(newPattern);
        }

        public static void AddMemberCharacterAssemblyPattern(ParticipationAssemblyPattern newPattern)
        {
            memberCharacterAssemblyPatterns.Enqueue(newPattern);
        }

        public static void AddNewControllingCharacter(int characterID)
        {
            if (!collectiveBeingDesigned.controllingCharacters.Contains(characterID))
                collectiveBeingDesigned.controllingCharacters.Add(characterID);
        }

        public static void AddNewMemberCharacter(int characterID)
        {
            if (!collectiveBeingDesigned.memberCharacters.Contains(characterID))
                collectiveBeingDesigned.memberCharacters.Add(characterID);
        }

        public static int SendToWorld(int worldNr = 0)
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