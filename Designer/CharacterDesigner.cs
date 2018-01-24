using System;
using System.Collections.Generic;
using System.Text;





public partial class Designer
{
    public class CharacterDesigner
    {
        Character characterBeingDesigned;
        Queue<AssemblyPattern.Character> assemblyPatterns;

        public void ResetToNewDesign()
        {
            characterBeingDesigned = new Character();
            assemblyPatterns = new Queue<AssemblyPattern.Character>();
        }

        public void AddSituation(Character.CharacterSituation situation)
        {
            characterBeingDesigned.situations.Add(situation);
        }

        public void AddOption(Character.CharacterOption option)
        {
            characterBeingDesigned.options.Add(option);
        }

        public void AddForecast(Character.CharacterForecast forecast)
        {
            characterBeingDesigned.forecasts.Add(forecast);
        }

        public void AddAssemblyPattern(AssemblyPattern.Character newPattern)
        {
            assemblyPatterns.Enqueue(newPattern);
        }

        public int SendToWorld(int worldNr = 0)
        {
            int id = Generator.GenerateCharacterFromDesign(characterBeingDesigned, assemblyPatterns);

            ResetToNewDesign();
            return id;
        }
    }
}