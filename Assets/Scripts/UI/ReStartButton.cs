using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReStartButton : MonoBehaviour
{

    [SerializeField] GameObject resultPanel;
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
