using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectibleCount : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ScoreText;
    int score;

    void Start()
    {
        ScoreText.text = "Score: " + score;
    }

    public void IncreaseScore()
    {
        score++;
        ScoreText.text = "Score: " + score;
    }
}
