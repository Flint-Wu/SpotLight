using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportScene : MonoBehaviour
{
    public string sceneFrom;

    public string sceneToGO;

    public void TeleportToScene()
    {
        TransitionManager.Instance.Transition(sceneFrom, sceneToGO);
    }
}
