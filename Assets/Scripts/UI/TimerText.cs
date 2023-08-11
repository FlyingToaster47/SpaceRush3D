using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerText : MonoBehaviour {
    [SerializeField] private TMP_Text timerText;


    private void Update() {
        timerText.text = "Time Left:" + "\n" + SecondsToMins();
    }

    private string SecondsToMins() {
        float time = GameManager.instance.GetTime();
        float mins = time / 60;
        float truncated = (mins - (int)mins);
        float secs = truncated * (truncated.ToString().Length-1) * 60;
        return ((int)mins).ToString() + ":" + ((int)secs).ToString() + "mins";
    }

}
