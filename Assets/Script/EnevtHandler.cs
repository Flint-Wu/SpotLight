using System;
using UnityEngine;

public static class EnevtHandler
{
    public static event Action BeforeSceneUnloadEvent;
    public static void CallBeforeSceneUnloadEvent()
    {
        BeforeSceneUnloadEvent?.Invoke();
    }

    public static event Action AfterSceneUnloadEvent;
    public static void CallAfterSceneUnloadEvent()
    {
        AfterSceneUnloadEvent?.Invoke();
    }

    public static event Action GameStateChangeEvent;
    public static void CallGameStateChangeEvent()
    {
        GameStateChangeEvent?.Invoke();
    }

}
