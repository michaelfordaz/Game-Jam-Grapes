using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingSwap : MonoBehaviour
{
    public Sprite paintingNormal;
    public Sprite paintingCreepyQuarter;
    public Sprite paintingCreepyTrans;
    public Sprite paintingCreepy;

    // Change the face to be creepy if player is to the right of it
    // And above -3 y
    void Update()
    {
        if (GameObject.FindWithTag("Player").transform.position.x > (transform.position.x + 1.0f) && GameObject.FindWithTag("Player").transform.position.y > -3.0f)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = paintingCreepy;
        }
        else if ((transform.position.x + 0.5f) < GameObject.FindWithTag("Player").transform.position.x && GameObject.FindWithTag("Player").transform.position.x < (transform.position.x + 1.0f) && GameObject.FindWithTag("Player").transform.position.y > -3.0f)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = paintingCreepyTrans;
        }
        else if (transform.position.x < GameObject.FindWithTag("Player").transform.position.x && GameObject.FindWithTag("Player").transform.position.x < (transform.position.x + 0.5f) && GameObject.FindWithTag("Player").transform.position.y > -3.0f)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = paintingCreepyQuarter;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = paintingNormal;
        }
    }
}
