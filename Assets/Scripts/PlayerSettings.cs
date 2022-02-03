using UnityEngine;

namespace Pong
{
    public static class PlayerSettings
    {
        private const string BallColor = "BallColor";
        private const string BestScore = "BestScore";

        public static Color LoadColor()
        {
            var stringColor = string.Empty;
            if (PlayerPrefs.HasKey(BallColor))
            { 
                stringColor = "#" + PlayerPrefs.GetString(BallColor);
            }

            if (ColorUtility.TryParseHtmlString(stringColor, out var color))
            {
                return color;
            }

            return Color.white;
        }

        public static void SaveColor(Color color)
        {
            var stringColor = ColorUtility.ToHtmlStringRGB(color);
            PlayerPrefs.SetString(BallColor, stringColor);
            PlayerPrefs.Save();
        }

        public static int LoadBestScore()
        {
            return PlayerPrefs.HasKey(BestScore) ? PlayerPrefs.GetInt(BestScore) : 0;
        }

        public static void SaveBestScore(int newBestScore)
        {
            PlayerPrefs.SetInt(BestScore, newBestScore);
            PlayerPrefs.Save();
        }
    }
}