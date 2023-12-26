using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    public TextMeshProUGUI Currant_score_text;
    public TextMeshProUGUI high_Score_text;

    private int currant_score;
    private int high_score;

    private void Start()
    {
        high_score = PlayerPrefs.GetInt("HighScore", 0);
        high_Score_text.text=high_score.ToString();
    }
    public void increasing_curaant_score()
    {
        currant_score++;
        Currant_score_text.text=currant_score.ToString();
        if (currant_score > high_score)
        {
            high_Score_text.text = currant_score.ToString();
            PlayerPrefs.SetInt("HighScore", currant_score);
        }
    }
}
