﻿using System;
using System.Collections.Generic;
using System.Text;






static class Command
{
    public static List<World> worlds = new List<World>();

    static int nextSimpleTemplateID = 0;
    public static int GetNewSimpleEntityTemplateID()
    {
        nextSimpleTemplateID++;
        return nextSimpleTemplateID;
    }
}