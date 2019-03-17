using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReStartButton : MonoBehaviour
{

    [SerializeField] GameObject resultPanel;

    bool isTapped;
    // Start is called before the first frame update
    void Start()
    {
        resultPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ReStart()
    {
        if (isTapped) return;
        isTapped = true;

        Variable.audioSource[1].Play();

        StartCoroutine(Checking(() =>
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
