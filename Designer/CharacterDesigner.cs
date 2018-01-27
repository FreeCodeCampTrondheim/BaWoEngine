using System.Collections.Generic;








public partial class Designer
{
    public static class CharacterDesigner
    {
        static Character characterBeingDesigned;
        static Queue<CharacterAssemblyPattern> assemblyPatterns;

        public static void ResetToNewDesign()
        {
            characterBeingDesigned = new Character();
            assemblyPatterns = new Queue<CharacterAssemblyPattern>();
        }

        public static void AddSituation(Character.CharacterSituation situation)
        {
            characterBeingDesigned.situations.Add(situation);
        }

        public static void AddOption(Character.CharacterOption option)
        {
            characterBeingDesigned.options.Add(option);
        }

        public static void AddForecast(Character.CharacterForecast forecast)
        {
            characterBeingDesigned.forecasts.Add(forecast);
        }

        public static void AddAssemblyPattern(CharacterAssemblyPattern newPattern)
        {
            assemblyPatterns.Enqueue(newPattern);
        }

        public static int SendToWorld(int worldNr = 0)
        {
            int id = Generator.GenerateCharacterFromDesign(characterBeingDesigned, assemblyPatterns);

            ResetToNewDesign();
            return id;
        }
    }
}