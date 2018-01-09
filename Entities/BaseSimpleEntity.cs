using System;
using System.Collections.Generic;
using System.Text;


public partial class Character
{
    public class BaseSimpleEntity
    {
        // which entity is responsible for launching this
        // situation/option/forecast, the target being the 
        // entity where this simple entity is listed
        public int sourceEntityID;

        // whether the source is a collective instead of a character
        public bool sourceIsCollective = false;
    }
}