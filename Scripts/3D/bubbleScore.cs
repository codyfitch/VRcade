using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bubbleScore : MonoBehaviour
{
    //Script to hold score for access in other scripts
    public int score;
    public Text scoreText;

    private void Update()
    {
        scoreText.text = score.ToString();
    }
}
