using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportScene : MonoBehaviour
{
    private Dictionary<SceneName, string> SceneCode  = new Dictionary<SceneName, string>()
    {
        { SceneName.L1,"L1"},
        { SceneName.L2,"L2"},
        { SceneName.L3,"L3"},
        { SceneName.L4,"L4"},
        { SceneName.L5,"L5"},
        { SceneName.L6,"L6"}
    };


    public string sceneFrom;

    public string sceneToGO;

    public void TeleportToScene()
    {
        TransitionManager.Instance.Transition(sceneFrom, sceneToGO);
    }
}
