using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyedNoise : MonoBehaviour
{
    public AudioSource clinkSound;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Destructable Vile") && collision.gameObject.GetComponent<Destructable>().surfaceObject != gameObject)
        {
            if (!clinkSound.isPlaying)
            {
                clinkSound.Play();
            }
        }
    }
}
