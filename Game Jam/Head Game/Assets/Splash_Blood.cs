using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splash_Blood : MonoBehaviour
{
    // Prefab of blood that'll be splashed
    public GameObject bloodSplash;
    // Stores the velocity before collision
    private Vector2 velocityBeforePhysicsUpdate;

    void FixedUpdate()
    {
        // Get the velocity
        // Will be used to get the velocity before collision
        velocityBeforePhysicsUpdate = GetComponent<Rigidbody2D>().velocity;
    }

    // Spawn blood and give it calculated velocity
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Wall"))
        {
            // Instantiate the blood
            var newBlood = Instantiate(bloodSplash, transform.position, Quaternion.identity);
            // Give the blood whichever velocity value (x or y) is higher
            if (Mathf.Abs(velocityBeforePhysicsUpdate.x) > Mathf.Abs(velocityBeforePhysicsUpdate.y))
            {
                newBlood.GetComponent<blood_properties>().createScale(Mathf.Abs(velocityBeforePhysicsUpdate.x));
            }
            else
            {
                newBlood.GetComponent<blood_properties>().createScale(Mathf.Abs(velocityBeforePhysicsUpdate.y));
            }
        }
    }
}
