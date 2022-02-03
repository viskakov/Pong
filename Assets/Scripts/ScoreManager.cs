using System;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static event Action<int> OnBestScoreChangedEvent;
    public static int BestScore { get; private set; }

    private static int _currentScore;

    private void Awake()
    {
        BestScore = PlayerSettings.LoadBestScore();
    }

    private void OnEnable()
    {
        Ball.OutOfScreenEvent += IncreasedScore;
    }

    private void OnDisable()
    {
        Ball.OutOfScreenEvent -= IncreasedScore;
    }

    private static void IncreasedScore()
    {
        _currentScore++;
        if (_currentScore > BestScore)
        {
            PlayerSettings.SaveBestScore(_currentScore);
            OnBestScoreChangedEvent?.Invoke(_currentScore);
        }
    }
}