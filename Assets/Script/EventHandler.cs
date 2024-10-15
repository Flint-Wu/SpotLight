using System;
using UnityEngine;

public static class EventHandler
{
    public static event Action BeforeSceneUnloadEvent;
    public static void CallBeforeSceneUnloadEvent()
    {
        BeforeSceneUnloadEvent?.Invoke();
    }

    public static event Action AfterSceneLoadedEvent;
    public static void CallAfterSceneLoadedEvent()
    {
        AfterSceneLoadedEvent?.Invoke();
    }


    public static event Action GameStateChangeEvent;
    public static void CallGameStateChangeEvent()
    {
        GameStateChangeEvent?.Invoke();
    }

    public static event Action<int> ScoreAddEvent;
    public static void CallScoreAddEvent(int score)
    {
        ScoreAddEvent?.Invoke(score);
    }

}
