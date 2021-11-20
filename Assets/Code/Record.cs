using System;
using UnityEngine;
using UnityEngine.UI;

public class Record : MonoBehaviour
{
    private static Text recordText; // everyone has the same text
    private static int record = 0;

    // Use this for initialization
    internal void Start()
    {
        recordText = GetComponent<Text>();
        UpdatebestText();
    }

    public static void GetRecord()
    {
        record = Mathf.Max(record, ScoreKeeper.score);
        UpdatebestText();
    }

    private static void UpdatebestText()
    {
        recordText.text = String.Format("Record: {0}", record);
    }
}
