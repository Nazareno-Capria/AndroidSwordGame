using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UI : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    public void SetScoreUI(int score)
    {
        scoreText.text = "SCORE:" + score;
    }
}
