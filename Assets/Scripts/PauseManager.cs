using UnityEngine;

public static class PauseManager
{
    public static void Pause()
    {
        Time.timeScale = 0f;
    }

    public static void Resume()
    {
        Time.timeScale = 1f;
    }
}