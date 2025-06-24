using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    void Start()
    {
        UpdateScoreUI();
    }

    void Update()
    {
        UpdateScoreUI();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ScoreManager.SaveScore(0);
        }
    }

    void UpdateScoreUI()
    {
        int score = ScoreManager.LoadScore();
        scoreText.text = $"Point: {score}";
    }
}
