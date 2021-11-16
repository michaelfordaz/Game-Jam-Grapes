using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceActivate : MonoBehaviour
{
    private GameObject[] bouncePads;
    private bool leftSurface = false;

    // A rat sqweak when you hit it
    public AudioSource ratSound;

    // For Blink Animation
    //public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        bouncePads = GameObject.FindGameObjectsWithTag("Bounce");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        /*if (GetComponent<Rigidbody2D>().velocity.y == 0 && !collision.gameObject.CompareTag("Bounce") && leftSurface == true)
        {
            print("enter");
            leftSurface = false;
        }*/
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (GetComponent<Rigidbody2D>().velocity.y == 0 && !collision.gameObject.CompareTag("Bounce") && leftSurface == true)
        {
            // Have head blink
            //GetComponent<Animator>().Play("Blink");
            //animator.SetBool("HitGround", true);
            //GetComponent<Animator>().SetTrigger("DoBlink");
            //print("enter");
            leftSurface = false;
        }
        if (collision.gameObject.CompareTag("JumpVile") && leftSurface == true)
        {
            leftSurface = false;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Bounce") && leftSurface == false)
        {
            //print("exit");
            leftSurface = true;
            foreach (GameObject bouncer in bouncePads)
            {
                bouncer.GetComponent<BounceRecieve>().Calculate();
            }
        }
        /*else
        {
            print("repeat");
            foreach (GameObject bouncer in bouncePads)
            {
                bouncer.GetComponent<BoxCollider2D>().sharedMaterial.bounciness = 1.0f;
            }
        }*/
        if (collision.gameObject.CompareTag("Bounce"))
        {
            // Play rat noise
            if (!ratSound.isPlaying)
            {
                ratSound.Play();
            }
            //print("repeat");
            foreach (GameObject bouncer in bouncePads)
            {
                bouncer.GetComponent<BoxCollider2D>().sharedMaterial.bounciness = 1.0f;
            }
        }
    }
}
