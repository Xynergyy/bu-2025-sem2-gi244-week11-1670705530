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
            return; 
        }

        if (player != null)
        {
            Vector3 dir = (player.transform.position - transform.position).normalized;
            rb.AddForce(dir * speed);
        }

        float distance = Vector3.Distance(transform.position, Vector3.zero);

        if (distance > 25f)
        {
            Destroy(gameObject);
        }
    }



    public void SetStun(bool value)
    {
        isStunned = value;
    }
}
