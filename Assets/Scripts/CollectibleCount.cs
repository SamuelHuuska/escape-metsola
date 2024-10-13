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
        ScoreText.text = score + "/8";
    }

    public void IncreaseScore()
    {
        score++;
        ScoreText.text = score + "/8";
    }
}
