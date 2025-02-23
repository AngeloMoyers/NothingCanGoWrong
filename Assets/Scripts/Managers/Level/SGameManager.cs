using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SGameManager
{
    public static int CurrentLevel = 0;

    public static int IterateLevel()
    {
        return ++CurrentLevel;
    }
}
