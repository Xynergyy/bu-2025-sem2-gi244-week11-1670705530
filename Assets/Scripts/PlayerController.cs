using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public Transform focalPoint;

    private Rigidbody rb;

    private PowerUp powerUpScript;
    private StunPowerUp stunPowerScript;

    private InputAction moveAction;
    private InputAction breakAction;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        powerUpScript = GetComponent<PowerUp>();
        stunPowerScript = GetComponent<StunPowerUp>();

        moveAction = InputSystem.actions.FindAction("Move");
        breakAction = InputSystem.actions.FindAction("Break");
    }

    void Update()
    {
        var move = moveAction.ReadValue<Vector2>();
        rb.AddForce(move.y * speed * focalPoint.forward);

        if (breakAction.IsPressed())
        {
            rb.linearVelocity = Vector3.zero;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && powerUpScript.hasPowerUp)
        {
            var enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            var dir = collision.transform.position - transform.position;
            dir.Normalize();
            enemyRb.AddForce(100 * dir, ForceMode.Impulse);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            Destroy(other.gameObject);
            powerUpScript.Activate(10f);
            stunPowerScript.ActivateStun();
        }
    }
}