using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public float bounce = 5f;
    private float jumpValue = 0f;

    //public float jumpHeight = 5f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpValue, ForceMode2D.Impulse);
            //collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpValue);

            /*Rigidbody2D rigid2D = collision.gameObject.GetComponent<Rigidbody2D>();
            if (rigid2D != null)
            {
                Vector2 force = new Vector2(0f, Mathf.Sqrt(2f * jumpHeight * Mathf.Abs(Physics2D.gravity.y)));

                float angle = transform.rotation.eulerAngles.z;

                force = Quaternion.Euler(0, 0, angle) * force;

                rigid2D.velocity = force;
            }*/
        }
    }

    public void Calculate()
    {
        float distance = Mathf.Abs(GameObject.FindWithTag("Player").transform.position.y - transform.position.y);
        //jumpValue = (bounce + distance) / distance;
        jumpValue = bounce + distance;
        //jumpValue *= 5;
        print(jumpValue);
        //print(distance);
        //bouncy.bounciness = multiplier;
        //print("hi");
    }
}
