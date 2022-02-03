using TMPro;
using UnityEngine;

namespace Pong
{
    public class ScoreLabelView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreLabel;
    
        private void Start()
        {
            var bestScore = ScoreManager.BestScore;
            SetBestScoreLabel(bestScore);
        }

        private void OnEnable()
        {
            ScoreManager.OnBestScoreChangedEvent += SetBestScoreLabel;
        }

        private void OnDisable()
        {
            ScoreManager.OnBestScoreChangedEvent -= SetBestScoreLabel;
        }
    
        private void SetBestScoreLabel(int value)
        {
            _scoreLabel.SetText($"Best Score: {value}");
        }
    }
}