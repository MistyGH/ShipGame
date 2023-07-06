using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ScoreDisplay : MonoBehaviour
{
    public GameObject ScoreHolder;
    public TextMeshProUGUI ThisTextBox;
    public float CurrentScore;

    // Update is called once per frame
    void Update()
    {
       CurrentScore = (ScoreHolder.GetComponent<ScoreManager>().returnScore());
       ThisTextBox.text = $"Score: {Math.Round(CurrentScore).ToString()}";
    }
}
