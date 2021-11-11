using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceMechanics : MonoBehaviour
{
    // Physics matierials to change how bouncy you bounce
    // Double height, 2.0 bounciness
    public PhysicsMaterial2D bouncy;
    // Same height, 1.0 bounciness
    public PhysicsMaterial2D sameBouncy;

    // Stores the bouncy part of all rats
    private GameObject[] bouncePads;

    // If the previous object that you touched is the rat, do not escalate jump height
    private bool restrictJumpHeight = false;

    // Start is called before the first frame update
    void Start()
    {
        // Find bouncy part of every rat
        bouncePads = GameObject.FindGameObjectsWithTag("Bounce");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Not rat and surface
        if (GetComponent<Rigidbody2D>().velocity.y == 0 && !collision.gameObject.CompareTag("Bounce"))
        {
            print("not rat");
            restrictJumpHeight = false;

            // Set each rat to bouncy
            foreach (GameObject bouncer in bouncePads)
            {
                bouncer.GetComponent<BoxCollider2D>().sharedMaterial = bouncy;
            }
            //collision.gameObject.GetComponent<BoxCollider2D>().sharedMaterial = bouncy;
        }
        /*// If you just bounced from the rat, the next bounce will not increase bounce height
        // Not rat and surface
        if (GetComponent<Rigidbody2D>().velocity.y == 0 && !collision.gameObject.CompareTag("Bounce"))
        {
            print("not rat");
            restrictJumpHeight = false;
        }*/
        // First Bounce
        if (collision.gameObject.CompareTag("Bounce") && restrictJumpHeight == false)
        {
            //print("frist bounce");
            // Bounce twice as high as drop height
            //collision.gameObject.GetComponent<BoxCollider2D>().sharedMaterial = bouncy;
            //collision.gameObject.GetComponent<BoxCollider2D>().sharedMaterial.bounciness = 2.0f;
            // Make changes take affect
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = true;
            // On the next bounce, retain this height
            restrictJumpHeight = true;
        }
        // Repetitive Bounce
        /*else if (collision.gameObject.CompareTag("Bounce") && restrictJumpHeight == true)
        {
            print("repetitive bounce");
            // Retain bounce height
            collision.gameObject.GetComponent<BoxCollider2D>().sharedMaterial.bounciness = 1.0f;
            // Make changes take affect
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }*/
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        // If you just bounced from the rat, the next bounce will not increase bounce height
        // Not rat and surface
        /*if (GetComponent<Rigidbody2D>().velocity.y == 0 && !collision.gameObject.CompareTag("Bounce"))
        {
            print("not rat");
            restrictJumpHeight = false;
        }*/
        // First Bounce
        if (collision.gameObject.CompareTag("Bounce") && restrictJumpHeight == false)
        {
            print("frist bounce");
            // Bounce twice as high as drop height
            collision.gameObject.GetComponent<BoxCollider2D>().sharedMaterial = sameBouncy;
            //collision.gameObject.GetComponent<BoxCollider2D>().sharedMaterial.bounciness = 1.0f;
            // Make changes take affect
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = true;
            // On the next bounce, retain this height
            restrictJumpHeight = true;
        }
        // Repetitive Bounce
        else if (collision.gameObject.CompareTag("Bounce") && restrictJumpHeight == true)
        {
            print("repetitive bounce");
            // Retain bounce height
            //collision.gameObject.GetComponent<BoxCollider2D>().sharedMaterial.bounciness = 1.0f;
            // Make changes take affect
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}
