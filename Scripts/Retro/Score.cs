using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score;
    public Text scoreText;

    //Script to hold the player score for other scripts to access
    private void Update()
    {
        scoreText.text = score.ToString();
    }
}
