using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toxicHiss : MonoBehaviour
{
    public AudioSource hissSound;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Destructable Vile"))
        {
            hissSound.Play();
            /*if (!hissSound.isPlaying)
            {
                hissSound.Play();
            }*/
        }
    }
}
