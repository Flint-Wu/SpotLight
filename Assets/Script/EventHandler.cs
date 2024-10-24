using System;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

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

    public static event Action<GameObject> EnemyDectedEvent;
    public static void CallEnemyDectedEvent(GameObject Enemy)
    {
        EnemyDectedEvent?.Invoke(Enemy);
    }

    public static event Action UIchange;
    public static void CallUIchange()
    {
        UIchange?.Invoke();
    }
}
