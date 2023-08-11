using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance;

    private float leftTime = 60 * 5;
    private int highScore = 0;
    [SerializeField] private GameObject gameOver;

    private void Awake() {
        instance = this;
    }

    private void Start() {
        if (PlayerPrefs.HasKey("HighScore")) {
            highScore = PlayerPrefs.GetInt("HighScore");
        } else {
            PlayerPrefs.SetInt("HighScore", highScore);
        }
    }

    private void Update() {
        if (leftTime > 0) {
            leftTime -= Time.deltaTime;
        } else {
            //GameOver
            GameOver();
        }
    }

    public void GameOver() {
        if (Player.GetScore() > highScore) {
            highScore = Player.GetScore();
            PlayerPrefs.SetInt("HighScore", highScore);
        }

        Player.SetScore(0);

        gameOver.SetActive(true);
        Time.timeScale = 0;
    }

    public float GetTime() {
        return leftTime;
    }

    public int GetHighScore() {
        return highScore;
    }

}
