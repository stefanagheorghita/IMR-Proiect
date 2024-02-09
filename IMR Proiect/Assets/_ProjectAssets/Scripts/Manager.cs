using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Manager : MonoBehaviour
{
    public GameObject[] Levels;
    public TextMeshProUGUI scoreText;

    int currentLevel;
    int score = 0;

    void Start()
    {
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
   
        if (scoreText != null)
        {
            scoreText.text = score.ToString() + " points";
        }
    }

    public void correctAnswer()
    {
        if (currentLevel + 1 != Levels.Length)
        {
            score += 20;
            Levels[currentLevel].SetActive(false);
            currentLevel++;
            Levels[currentLevel].SetActive(true);
            UpdateScoreText();
        }
    }

    public void wrongAnswer()
    {
        if (currentLevel + 1 != Levels.Length)
        {
            Levels[currentLevel].SetActive(false);
            currentLevel++;
            Levels[currentLevel].SetActive(true);
            UpdateScoreText();
        }
    }
}

