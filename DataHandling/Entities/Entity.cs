using System;
using System.Collections.Generic;
using System.Text;





// where in-game entity classes are defined
namespace Entity
{
    #region INTERFACES AND BASE CLASSES
    // data and methods that all entities must have
    public abstract class BaseEntity
    {
        // ran through DataBank.cs -> Entity
        public abstract void UpdateData(DateTime d);
    }

    interface IDescribeable
    {
        string GetDescription();
    }
    #endregion
}