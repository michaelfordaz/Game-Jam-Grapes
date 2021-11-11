using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingSwap : MonoBehaviour
{
    public Sprite paintingNormal;
    public Sprite paintingCreepy;

    // Change the face to be creepy if player is to the right of it
    void Update()
    {
        if (GameObject.FindWithTag("Player").transform.position.x > transform.position.x)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = paintingCreepy;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = paintingNormal;
        }
    }
}
