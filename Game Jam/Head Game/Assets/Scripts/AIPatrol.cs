using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPatrol : MonoBehaviour
{
    public float walkSpeed;

    public bool mustPatrol;
    public bool mustTurn;

    public Rigidbody2D rb;
    public Transform groundCheckPosition;
    public LayerMask groundLayer;

    public Collider2D bodyCollider;

    // Start is called before the first frame update
    void Start()
    {
        mustPatrol = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (mustPatrol)
        {
            Patrol();
        }
    }

    void Patrol()
    {
        if(bodyCollider.IsTouchingLayers(groundLayer))
        {
           // Debug.Log("Let's fucking turn around");
            Flip();
        }
        rb.velocity = new Vector2(-walkSpeed * Time.fixedDeltaTime, rb.velocity.y);
    }

    void Flip()
    {
        transform.localScale = new Vector2(transform.localScale.x, transform.localScale.y * -1);
        walkSpeed *= -1;
        mustPatrol = true;
    }
}
