using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour
{
    public bool hasPowerUp; 
    public GameObject ringIndicator;
    public float rotationSpeed = 150f;
    public Vector3 offset = Vector3.zero;

    void Update()
    {
        if (ringIndicator == null || !hasPowerUp)
        {
            if (ringIndicator != null) ringIndicator.SetActive(false);
            return;
        }

        ringIndicator.SetActive(true);
        ringIndicator.transform.position = transform.position + offset;
        ringIndicator.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }

    public void Activate(float duration)
    {
        StopAllCoroutines();
        StartCoroutine(PowerUpCountDown(duration));
    }

    IEnumerator PowerUpCountDown(float duration)
    {
        hasPowerUp = true;
        yield return new WaitForSeconds(duration);
        hasPowerUp = false;
    }
}
