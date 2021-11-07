using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D m_Rigidbody;
    public float m_Thrust = 20f;

    public float horizontalInput;
    public bool touchingGround;

    public GameObject trailObject;

    public AudioSource squishSound;
    public AudioSource splatSound;

    public Transform respawnPoint;

    void Start()
    {
        //Fetch the Rigidbody from the GameObject with this script attached
        m_Rigidbody = GetComponent<Rigidbody2D>();
        touchingGround = false;
        trailObject.GetComponent<TrailRenderer>().emitting = false;

        squishSound.Play();
        squishSound.loop = true; //starts playing the squishSound.
        squishSound.mute = true; //mutes the squishSound
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");          
    }

    void FixedUpdate()
    {
        m_Rigidbody.AddForce(new Vector3(horizontalInput, 0.0f, 0) * m_Thrust);
    }

    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!splatSound.isPlaying)
        {
            splatSound.Play();
        }
    }
    

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            trailObject.GetComponent<TrailRenderer>().emitting = true;
            touchingGround = true;
            squishSound.mute = false; //mutes the squishSound
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            trailObject.GetComponent<TrailRenderer>().emitting = false;
            touchingGround = false;
            squishSound.mute = true; //mutes the squishSound
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Rat"))
        {
            gameObject.GetComponent<PlayerController>().trailObject.GetComponent<TrailRenderer>().emitting = false;
            gameObject.GetComponent<PlayerController>().touchingGround = false;
            gameObject.GetComponent<PlayerController>().squishSound.mute = true;

            gameObject.transform.position = respawnPoint.position;
            gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            gameObject.GetComponent<Rigidbody2D>().angularVelocity = 0f;
        }
    }
}
