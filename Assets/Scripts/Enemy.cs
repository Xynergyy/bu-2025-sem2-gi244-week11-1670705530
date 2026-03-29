using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3f;
    
    public bool isStunned = false;

    private Rigidbody rb;
    private GameObject player;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        
    }

    void Update()
    {
        if (StunPowerUp.isGlobalStunned)
        {
            rb.linearVelocity = Vector3.zero;
            return; // หยุดการทำงานบรรทัดล่างทันที
        }

        if (player != null)
        {
            Vector3 dir = (player.transform.position - transform.position).normalized;
            rb.AddForce(dir * speed);
        }
    }

    public void SetStun(bool value)
    {
        isStunned = value;
    }
}
