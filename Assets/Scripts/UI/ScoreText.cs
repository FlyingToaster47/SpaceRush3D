using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour {
    [SerializeField] private TMP_Text scoreText;

    private void Update() {
        scoreText.text = Player.GetScore().ToString();
    }

}
