using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectibleCount : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ScoreText;
    private int score;

    void Start()
    {
        ScoreText.text = score + "/5";
    }

    public void IncreaseScore()
    {
        score++;
        ScoreText.text = score + "/5";
    }

    public int GetScore()
    {
        return score;
    }
}
