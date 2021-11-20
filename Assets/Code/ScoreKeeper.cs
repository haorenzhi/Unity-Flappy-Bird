using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    public static int score = 0;  // everyone has the same score
    private static Text scoreText; // everyone has the same text

    // Use this for initialization
    internal void Start()
    {
        scoreText = GetComponent<Text>();
        UpdateText();

    }

    public static void AddToScore(int points)
    {
        score += points;
        UpdateText();
    }
    public static void ClearScore()
    {
        score = 0;
        UpdateText();
    }

    private static void UpdateText()
    {
        scoreText.text = String.Format("Score: {0}", score);
    }
}
