using TMPro;
using UnityEngine;

namespace Pong
{
    public class ScoreLabelView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreLabel;
        [SerializeField] private TextMeshProUGUI _currentScoreLabel;

        private void Start()
        {
            UpdateBestScoreLabel(ScoreManager.BestScore);
            UpdateCurrentScoreLabel(ScoreManager.CurrentScore);
        }

        private void OnEnable()
        {
            ScoreManager.OnBestScoreChangedEvent += UpdateBestScoreLabel;
            ScoreManager.OnCurrentScoreChangedEvent += UpdateCurrentScoreLabel;
        }

        private void OnDisable()
        {
            ScoreManager.OnBestScoreChangedEvent -= UpdateBestScoreLabel;
            ScoreManager.OnCurrentScoreChangedEvent -= UpdateCurrentScoreLabel;
        }
    
        private void UpdateBestScoreLabel(int value)
        {
            _scoreLabel.SetText($"Best Score: {value}");
        }

        private void UpdateCurrentScoreLabel(int value)
        {
            _currentScoreLabel.SetText($"Current Score: {value}");
        }
    }
}