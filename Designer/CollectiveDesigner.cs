using System.Collections.Generic;








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

        public static void AddNewControllingCharacter(Character c)
        {
            if (!collectiveBeingDesigned.controllingCharacters.Contains(c))
                collectiveBeingDesigned.controllingCharacters.Add(c);
        }

        public static void AddNewMemberCharacter(Character c)
        {
            if (!collectiveBeingDesigned.memberCharacters.Contains(c))
                collectiveBeingDesigned.memberCharacters.Add(c);
        }

        public static int SendToWorld(int worldNr = 0)
        {
            World w = Command.worlds[worldNr];
            int id = Generate(
                w,
                collectiveBeingDesigned,
                assemblyPatterns,
                controllingCharacterAssemblyPatterns,
                memberCharacterAssemblyPatterns);

            ResetToNewDesign();
            return id;
        }
    }
}