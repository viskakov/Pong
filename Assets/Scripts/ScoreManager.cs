using System;
using UnityEngine;

namespace Pong
{
    public class ScoreManager : MonoBehaviour
    {
        public static event Action<int> OnBestScoreChangedEvent;
        public static event Action<int> OnCurrentScoreChangedEvent;
        public static int BestScore { get; private set; }
        public static int CurrentScore { get; private set; }

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
            CurrentScore++;
            OnCurrentScoreChangedEvent?.Invoke(CurrentScore);

            if (CurrentScore > BestScore)
            {
                PlayerSettings.SaveBestScore(CurrentScore);
                OnBestScoreChangedEvent?.Invoke(CurrentScore);
            }
        }
    }
}