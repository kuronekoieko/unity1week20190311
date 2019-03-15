using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{

    [SerializeField] GameObject tutrialDialogPanel;
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
        Variable.gameState = GameState.COUNT_DOWN;
        Time.timeScale = 1.0f;
        tutrialDialogPanel.SetActive(false);

    }
}
