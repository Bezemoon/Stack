using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] Player _player;
    [SerializeField] TMP_Text _scoreDisplay;

    private void OnEnable()
    {
        _player.ScoreChanged += OnScoreChanged;
    }

    private void OnDisable()
    {
        _player.ScoreChanged -= OnScoreChanged;
    }

    private void OnScoreChanged(int score)
    {
        _scoreDisplay.text = score.ToString();
    }
}
