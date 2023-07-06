using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ScoreManager : MonoBehaviour
{
    public GameObject XpHolder;
    public TextMeshProUGUI highScoreDisplay;

    public float score = 0;
    // Start is called before the first frame update
    void Start()
    {
        highScoreDisplay.text = $"Highscore: {PlayerPrefs.GetFloat("Highscore",0)}";
    }

    // Update is called once per frame
    void Update()
    {
        // score += (XpHolder.GetComponent<ShootCanon>().returnXP() * Time.deltaTime);
        score += (100 * Time.deltaTime);
        CheckHighScore();
    }

    public float returnScore() {
        return score;
    }

    public void CheckHighScore() {
        if (score > PlayerPrefs.GetFloat("Highscore",0)) {
            PlayerPrefs.SetFloat("Highscore",(float)(Math.Round(score)));
            highScoreDisplay.text = $"Highscore: {Math.Round(PlayerPrefs.GetFloat("Highscore",0))}";
        }
    }
}
