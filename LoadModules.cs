using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;




static partial class Catalogue
{
    // Call module functions within designated code regions using their name
    static void LoadModules()
    {
        #region Initialization
        CharacterTemplating.Initialize();
        CollectiveTemplating.Initialize();
        #endregion

        #region CharacterModules
        WillpowerModule();   // example of function call

        #endregion

        #region CollectiveModules
        FundamentalCollectiveModule();  // example of function call

        #endregion
    }
}