using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    private int _currentScore;
    private int _totalScore;

    public UnityAction<int> ScoreChanged;

    private void Start()
    {
        ResetScore();
    }

    public void IncreaseScore()
    {
        _currentScore++;
        ScoreChanged?.Invoke(_currentScore);
    }

    private void ResetScore()
    {
        _currentScore = 0;

        if (_currentScore > _totalScore)
            _totalScore = _currentScore;
    }
}
