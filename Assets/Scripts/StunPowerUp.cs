using UnityEngine;
using System.Collections;

public class StunPowerUp : MonoBehaviour
{
    public static bool isGlobalStunned = false;
    public float stunDuration = 5f;

    public void ActivateStun()
    {
        StopAllCoroutines();
        StartCoroutine(StunRoutine());
    }

    IEnumerator StunRoutine()
    {
        isGlobalStunned = true; 
        yield return new WaitForSeconds(stunDuration);
        isGlobalStunned = false; 
    }
}
