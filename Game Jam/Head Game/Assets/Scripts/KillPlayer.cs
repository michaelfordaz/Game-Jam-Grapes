using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    public Transform respawnPoint;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerController>().trailObject.GetComponent<TrailRenderer>().emitting = false;
            collision.gameObject.GetComponent<PlayerController>().touchingGround = false;
            collision.gameObject.GetComponent<PlayerController>().squishSound.mute = true;

            collision.gameObject.transform.position = respawnPoint.position;
            collision.gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            collision.gameObject.GetComponent<Rigidbody2D>().angularVelocity = 0f;
        }
    }
}
