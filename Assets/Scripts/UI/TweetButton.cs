using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweetButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Tweet()
    {
        string link = "\n\n" + Variable.gameLink;
        link = "";
        string tweetText = "お友達になったﾈｺﾁｬﾝは…\n" + Variable.catCount + " 匹\nでした！みんなもやってみよう！！！" + link + "\n\n#つながるﾈｺﾁｬﾝ\n#unity1week";
        Application.OpenURL("http://twitter.com/intent/tweet?text=" + WWW.EscapeURL(tweetText));
    }
}
