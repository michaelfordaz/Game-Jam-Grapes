using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceActivate : MonoBehaviour
{
    // This will store all rats
    private GameObject[] bouncePads;
    // This will store all rat locations
    private Transform[] ratTransforms;
    private bool leftSurface = false;
    private bool touchingGroundObject = false;

    // A rat sqweak when you hit it
    public AudioSource ratSound;
    public Transform respawnPoint;

    // For Blink Animation
    //public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        bouncePads = GameObject.FindGameObjectsWithTag("Bounce");
        // Get the transforms of all rats and store in a list
        // This will be used to find the nearest rat
        ratTransforms = new Transform[bouncePads.Length];
        for (int i = 0; i < ratTransforms.Length; i++)
        {
            ratTransforms[i] = bouncePads[i].transform;
        }
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
        if (collision.gameObject.CompareTag("Ground"))
        {
            touchingGroundObject = true;
        }
        if (collision.gameObject.CompareTag("Bounce") && touchingGroundObject == true)
        {
            // Play rat noise
            if (!ratSound.isPlaying)
            {
                ratSound.Play();
            }
            gameObject.GetComponent<PlayerController>().trailObject.GetComponent<TrailRenderer>().emitting = false;
            gameObject.GetComponent<PlayerController>().touchingGround = false;
            gameObject.GetComponent<PlayerController>().squishSound.mute = true;

            gameObject.transform.position = respawnPoint.position;
            gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            gameObject.GetComponent<Rigidbody2D>().angularVelocity = 0f;
        }
        else if(collision.gameObject.CompareTag("Bounce") && !collision.gameObject.CompareTag("Ground"))
        {
            // Squish the closest rat
            StartCoroutine(doSquish(GetClosestEnemy(ratTransforms).gameObject));
            //StartCoroutine(doSquish(collision));
            //GetClosestEnemy(ratTransforms);
        }
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
        if (collision.gameObject.CompareTag("Ground"))
        {
            touchingGroundObject = false;
        }
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
                //bouncer.GetComponent<BoxCollider2D>().sharedMaterial.bounciness = 1.0f;
                bouncer.GetComponent<EdgeCollider2D>().sharedMaterial.bounciness = 1.0f;
            }
            // Squish the rat
            //collision.gameObject.GetComponent<Animator>().SetTrigger("DoSquish");
            //StartCoroutine(doSquish(collision));
        }
    }

    /*IEnumerator doSquish(Collision2D collision)
    {
        collision.gameObject.GetComponent<Animator>().SetTrigger("DoSquish");
        yield return new WaitForSeconds(0.2f);
        collision.gameObject.GetComponent<Animator>().SetTrigger("DoSquish");
    }*/

    // Squish using gameObject instead of collision
    IEnumerator doSquish(GameObject nearestRat)
    {
        nearestRat.GetComponent<Animator>().SetTrigger("DoSquish");
        yield return new WaitForSeconds(0.2f);
        nearestRat.GetComponent<Animator>().SetTrigger("DoSquish");
    }

    // Find nearest rat
    Transform GetClosestEnemy(Transform[] enemies)
    {
        Transform tMin = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        foreach (Transform t in enemies)
        {
            float dist = Vector3.Distance(t.position, currentPos);
            if (dist < minDist)
            {
                tMin = t;
                minDist = dist;
            }
        }
        return tMin;
    }
}
