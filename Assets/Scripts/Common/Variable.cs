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

public enum CatState
{
    TOUCH_WATER,//プレイヤーが水たまりに接触した瞬間
    RELEASE,//自由に歩き回ってるとき
    TOUCH_PLAYER,//プレイヤーに接触した瞬間
    CHASE,//追従中
}

public class Variable
{

    public static void InitVariable()
    {
        catCount = 0;
        Variable.gameState = GameState.TUTORIAL;
    }

    public static float walkSpeed = 15.0f;

    public static int catCount;
    public static float limitTimeSec = 40;

    public static float cam_range_x = 1.0f;
    public static float cam_range_y = 0.5f;
    public static float resultIntervalSec = 2.0f;
    public static GameState gameState;

    public static string gameLink = "https://unityroom.com/games/tunagaru_nekochan";

    public static AudioSource[] audioSource;
}
