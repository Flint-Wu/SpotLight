
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public Image[] healths;

    public PlayerState playerState;

    [SerializeField]
    private float HealthSat;

    void Start()
    {
        playerState = GameObject.FindAnyObjectByType<PlayerState>();
        HealthSat = playerState.Health;

        healths = GetComponentsInChildren<Image>();

    }

    // Update is called once per frame
    void Update()
    {
        HealthSat = playerState.Health;

        if (HealthSat > 0 && HealthSat < playerState.maxHealth / 3)
        {
            healths[0].fillAmount = HealthSat / (playerState.maxHealth / 3);
            healths[1].fillAmount = 0;
            healths[2].fillAmount = 0;
        }
        else if (HealthSat > playerState.maxHealth / 3 && HealthSat < playerState.maxHealth / 3 * 2)
        {
            healths[0].fillAmount = 1;
            healths[1].fillAmount = (HealthSat - playerState.maxHealth / 3) / (playerState.maxHealth / 3);
            healths[2].fillAmount = 0;
        }
        else if (HealthSat > playerState.maxHealth / 3 * 2 && HealthSat < playerState.maxHealth) 
        {
            healths[0].fillAmount = 1;
            healths[1].fillAmount = 1;
            healths[2].fillAmount = (HealthSat - playerState.maxHealth / 3 * 2) / (playerState.maxHealth / 3);
        }



    }
}
