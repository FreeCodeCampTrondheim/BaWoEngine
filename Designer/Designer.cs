using System;
using System.Collections.Generic;
using System.Text;






public partial class Designer
{
    public List<AssemblyPattern.Character> characterAssemblyPatterns;
    public List<AssemblyPattern.Collective> collectiveAssemblyPatterns;
    public List<AssemblyPattern.ControllingCharacter> controllingCharacterAssemblyPatterns;
    public List<AssemblyPattern.MemberCharacter> memberCharacterAssemblyPatterns;

    #region Register Assembly Patterns
    public int RegisterAssemblyPattern(AssemblyPattern.Character pattern)
    {
        if(!characterAssemblyPatterns.Contains(pattern))
        {
            characterAssemblyPatterns.Add(pattern);
            return characterAssemblyPatterns.Count;
        }
        else
        {
            return characterAssemblyPatterns.IndexOf(pattern);
        }
    }

    public int RegisterAssemblyPattern(AssemblyPattern.Collective pattern)
    {
        if (!collectiveAssemblyPatterns.Contains(pattern))
        {
            collectiveAssemblyPatterns.Add(pattern);
            return collectiveAssemblyPatterns.Count;
        }
        else
        {
            return collectiveAssemblyPatterns.IndexOf(pattern);
        }
    }

    public int RegisterAssemblyPattern(AssemblyPattern.ControllingCharacter pattern)
    {
        if (!controllingCharacterAssemblyPatterns.Contains(pattern))
        {
            controllingCharacterAssemblyPatterns.Add(pattern);
            return controllingCharacterAssemblyPatterns.Count;
        }
        else
        {
            return controllingCharacterAssemblyPatterns.IndexOf(pattern);
        }
    }

    public int RegisterAssemblyPattern(AssemblyPattern.MemberCharacter pattern)
    {
        if (!memberCharacterAssemblyPatterns.Contains(pattern))
        {
            memberCharacterAssemblyPatterns.Add(pattern);
            return memberCharacterAssemblyPatterns.Count;
        }
        else
        {
            return memberCharacterAssemblyPatterns.IndexOf(pattern);
        }
    }
    #endregion
}