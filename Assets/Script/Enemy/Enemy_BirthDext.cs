using UnityEngine;

public class Enemy_BirthDext : MonoBehaviour
{
    public bool BossBirth;
    public bool BrithAllow;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Respawn"))
        {
            BrithAllow = true;
        }
        else if(other == null || !other.CompareTag("Respawn"))
        {
            BrithAllow = false;
        }

        if (other.CompareTag("BossBIrth"))
        {
            BrithAllow = true;
            BossBirth = true;
        }
        else if (other == null || !other.CompareTag("BossBIrth"))
        {
            BrithAllow = false;
            BossBirth = false;
        }
    }
}
