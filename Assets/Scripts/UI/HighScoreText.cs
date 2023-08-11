using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScoreText : MonoBehaviour {
    [SerializeField] private TMP_Text highScoreText;

    private void Update() {
        highScoreText.text = "High Score" + "\n" + GameManager.instance.GetHighScore().ToString();
    }

}
