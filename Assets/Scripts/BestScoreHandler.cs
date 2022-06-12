using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestScoreHandler : MonoBehaviour
{
    private Text bestScoreText;
    private int bestScore;
    private string UserName;

    private void Awake()
    {
        bestScoreText = GetComponent<Text>();
        bestScore = GameManager.Instance.bestScore;
        UserName = GameManager.Instance.Username;
    }

    private void Update()
    {
        bestScoreText.text = "Best Score: " + UserName + " : " + bestScore;
    }
}
