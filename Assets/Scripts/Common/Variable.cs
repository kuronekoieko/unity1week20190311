using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Variable
{

    public static void InitVariable()
    {
        catCount = 0;
        isTimeUp = false;
        isStart = false;
    }

    public static float walkSpeed = 15.0f;

    public static int catCount;

    public static bool isTimeUp;

    public static float limitTimeSec = 30;

    public static float cam_range_x = 1.0f;
    public static float cam_range_y = 0.5f;
    public static bool isStart;
}
