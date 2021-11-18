using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPadActivate : MonoBehaviour
{
    private GameObject[] jumpPads;
    private bool leftSurface = false;

    void Start()
    {
        jumpPads = GameObject.FindGameObjectsWithTag("Jump Pad");
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (GetComponent<Rigidbody2D>().velocity.y == 0 && !collision.gameObject.CompareTag("Jump Pad") && leftSurface == true)
        {
            leftSurface = false;
        }
        if (collision.gameObject.CompareTag("JumpVile") && leftSurface == true)
        {
            leftSurface = false;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Jump Pad") && leftSurface == false)
        {
            leftSurface = true;
            foreach (GameObject pad in jumpPads)
            {
                pad.GetComponent<JumpPad>().Calculate();
            }
        }
    }
}
