using UnityEngine;

public static class PlayerSettings
{
    public static Color LoadColor()
    {
        var stringColor = string.Empty;
        if (PlayerPrefs.HasKey("BallColor"))
        { 
            stringColor = "#" + PlayerPrefs.GetString("BallColor");
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
        PlayerPrefs.SetString("BallColor", stringColor);
        PlayerPrefs.Save();
    }
}