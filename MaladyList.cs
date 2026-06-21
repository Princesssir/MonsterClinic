using System;
using System.Collections.Generic;

public static class MaladyList

    //all the Maladies that we have (placeholders ofc)
{
    public static Dictionary<string, Malady> Database = new()
    {
        ["TestInjury"] = new Malady { name = "TestInjury"},
        ["TestDisease"] = new Malady { name = "TestDisease"},
    };
}
