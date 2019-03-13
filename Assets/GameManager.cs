using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [SerializeField] Text timeText;
    [SerializeField] Text catCountText;
    float second;
    //float limitTimeSec = 30;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (second > Variable.limitTimeSec)
        {
            timeText.text = "Time UP!!!!";
            Variable.isTimeUp = true;
        }
        else
        {
            timeText.text = (Variable.limitTimeSec - second).ToString("F");
        }
        second += Time.deltaTime;

        catCountText.text = "ﾈｺﾁｬﾝ " + Variable.catCount.ToString() + " 匹";


    }



}
