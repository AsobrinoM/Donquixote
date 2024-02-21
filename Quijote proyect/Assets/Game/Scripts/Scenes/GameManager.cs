using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameObject gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        DontDestroyOnLoad(gameManager);
    }

    void Update()
    {   
        if (Input.GetKeyDown(KeyCode.R))
        {
            ChangeScene("Tutorial");
        }
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
