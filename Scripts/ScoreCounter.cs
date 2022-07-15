using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    public static ScoreCounter Instance;

    [SerializeField] private TextMeshProUGUI _currentScore;

    private int _score = 0;

    private void Awake()
    {
        Instance = this;
    }

    public void AddPoints(int points)
    {
        _score += points;
        _currentScore.text = _score.ToString("0");
    }

}
