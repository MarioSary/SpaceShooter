using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private GameManager _gameManager;
    
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _highscoreText;
    
    [SerializeField] private Text _gameOverText;
    [SerializeField] private Text _restartText;
    
    [SerializeField] private Image _livesSprite;
    [SerializeField] private Sprite[] _playerLives;

    void Start()
    {
        _gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();
        if (_gameManager == null)
        {
            Debug.LogError("Game Manager is NULL.");
        }
        _gameOverText.gameObject.SetActive(false);
        _restartText.gameObject.SetActive(false);
        _livesSprite.sprite = _playerLives[3];
        
        _scoreText.text = "Score:" + 0;
        _highscoreText.text = "Highscore: " + PlayerPrefs.GetInt("highscore").ToString();
    }


    public void UpdateScore(int playerScore)
    {
        _scoreText.text = "Score: " + playerScore;
    }

    public void UpdateHighScore(int currentHighscore)
    {
        //for updating the highscore during the game
        _highscoreText.text = "Highscore: " + currentHighscore;
        //for setting highscore
        PlayerPrefs.SetInt("highscore", currentHighscore);
    }

    public void UpdatePlayerLives(int currentLives)
    {
        _livesSprite.sprite = _playerLives[currentLives];
        if (currentLives == 0)
        {
            GameOverSequence();
        }
    }

    public void GameOverSequence()
    {
        _gameManager.GameOver();
        _gameOverText.gameObject.SetActive(true);
        _restartText.gameObject.SetActive(true);
        StartCoroutine(GameOverFlickerRoutine());
    }

    IEnumerator GameOverFlickerRoutine()
    {
        while (true)
        {
            _gameOverText.text = "GAME OVER";
            yield return new WaitForSeconds(0.5f);
            _gameOverText.text = "";
            yield return new WaitForSeconds(0.5f);
        }
    }
}
