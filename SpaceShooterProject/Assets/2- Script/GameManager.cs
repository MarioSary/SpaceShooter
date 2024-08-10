using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool _isGameOver;
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKey(KeyCode.R) && _isGameOver == true)
        {
            SceneManager.LoadScene(1); // 0 is current scene here
        }
    }

    public void GameOver()
    {
        _isGameOver = true;
    }
}
