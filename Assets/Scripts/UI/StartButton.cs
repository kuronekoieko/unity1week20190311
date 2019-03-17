using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{

    [SerializeField] GameObject tutrialDialogPanel;
    bool isTapped;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GameStart()
    {
        if (isTapped) return;
        isTapped = true;
        Variable.audioSource[1].Play();
        Time.timeScale = 1.0f;
        StartCoroutine(Checking(() =>
               {
                   Variable.audioSource[2].Play();
                   Variable.gameState = GameState.COUNT_DOWN;
                   tutrialDialogPanel.SetActive(false);
               }));

    }

    public delegate void functionType();
    private IEnumerator Checking(functionType callback)
    {
        while (true)
        {
            yield return new WaitForFixedUpdate();
            if (!Variable.audioSource[1].isPlaying)
            {
                callback();
                break;
            }
        }
    }
}
