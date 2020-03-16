using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VectorScore : MonoBehaviour
{
    public Text scoreText;
    public int score = 0;

    //Hold score for other scripts to access
    private void Update()
    {
        scoreText.text = score.ToString();
    }
}
