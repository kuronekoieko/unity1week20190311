using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [SerializeField] Text timeText;
    [SerializeField] Text catCountText;
    [SerializeField] Text resultCatCountText;

    [SerializeField] GameObject resultPanel;
    float second;
    //float limitTimeSec = 30;


    // Start is called before the first frame update
    void Start()
    {
        Variable.InitVariable();
        timeText.text = Variable.limitTimeSec.ToString() + ".00";
        catCountText.text = "ﾈｺﾁｬﾝ " + Variable.catCount.ToString() + " 匹";

    }

    // Update is called once per frame
    void Update()
    {

        if (!Variable.isStart) return;

        TextChange();

    }

    void TextChange()
    {
        if (second > Variable.limitTimeSec)
        {
            timeText.text = "Time UP!!!!";
            Variable.isTimeUp = true;
            resultCatCountText.text = Variable.catCount.ToString();
            resultPanel.SetActive(true);
        }
        else
        {
            timeText.text = (Variable.limitTimeSec - second).ToString("F");
        }
        second += Time.deltaTime;

        catCountText.text = "ﾈｺﾁｬﾝ " + Variable.catCount.ToString() + " 匹";

    }


}
