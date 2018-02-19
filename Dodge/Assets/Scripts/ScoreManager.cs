using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    public Text scoreText;
    public int scoreCount;

    private void Start()
    {
        scoreCount = 0;
    }

    private void Update()
    {
        scoreText.text = "" + Mathf.Round(scoreCount);
    }

    public void AddScore(int scoreToAdd)
    {
        scoreCount += scoreToAdd;
    }
}
