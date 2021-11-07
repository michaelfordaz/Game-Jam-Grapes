using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    public GameObject surfaceObject;
    public GameObject deathEffect;

    public AudioSource clinkSound;

    public bool beenTouched = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && beenTouched == false)
        {
            beenTouched = true;
            if (!clinkSound.isPlaying)
            {
                print("1");
                clinkSound.Play();
            }
        }
        else if (collision.gameObject.CompareTag("Destructable Vile") && collision.gameObject.GetComponent<Destructable>().beenTouched == true && beenTouched == false)
        {
            beenTouched = true;
            if (!clinkSound.isPlaying)
            {
                print("2");
                clinkSound.Play();
            }
        }
        /*if ((collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Destructable Vile")) && beenTouched == false)
        {
            if (!clinkSound.isPlaying)
            {
                clinkSound.Play();
            }
            beenTouched = true;
        }*/
        if (!collision.gameObject.CompareTag("Player") && collision.gameObject != surfaceObject && !collision.gameObject.CompareTag("Destructable Vile"))
        {
            Die();
            //Destroy(gameObject);
            //Instantiate(deathEffect);
            //Destroy(deathEffect, 2);
        }
    }

    public virtual void Die()
    {
        GameObject newEffect = Instantiate(deathEffect, gameObject.transform.position, deathEffect.transform.rotation);
        Destroy(newEffect, 0.5f);
        Destroy(gameObject);
        //GameObject newEffect = Instantiate(deathEffect);
        //Destroy(newEffect, 2);
    }
}
