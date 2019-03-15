using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    TUTORIAL,
    COUNT_DOWN,
    PLAY,
    RESULT,
}

public class Variable
{

    public static void InitVariable()
    {
        catCount = 0;
        Variable.gameState = GameState.TUTORIAL;
    }

    public static float walkSpeed = 13.0f;

    public static int catCount;
    public static float limitTimeSec = 30;

    public static float cam_range_x = 1.0f;
    public static float cam_range_y = 0.5f;
    public static float resultIntervalSec = 2.0f;
    public static GameState gameState;

    public static string gameLink = "https://mobile.twitter.com/kuronekoieko";
}
