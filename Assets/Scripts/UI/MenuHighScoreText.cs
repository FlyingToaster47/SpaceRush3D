using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuHighScoreText : MonoBehaviour {
    [SerializeField] private TMP_Text highScoreText; 
    private int highScore = 0;

    private void Start() {
        if (PlayerPrefs.HasKey("HighScore")) {
            highScore = PlayerPrefs.GetInt("HighScore");
        } else {
            PlayerPrefs.SetInt("HighScore", highScore);
        }

        highScoreText.text = "High Score:" + "\n" + highScore.ToString();
    }

}
