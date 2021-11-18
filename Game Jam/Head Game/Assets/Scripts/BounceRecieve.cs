using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceRecieve : MonoBehaviour
{
    private PhysicsMaterial2D bouncy;
    public float additive = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        // Create a new PhysicsMaterial2D to work with and overwrite
        bouncy = new PhysicsMaterial2D();
        //gameObject.GetComponent<BoxCollider2D>().sharedMaterial = bouncy;
        // Testing Purposes, Change:
        gameObject.GetComponent<EdgeCollider2D>().sharedMaterial = bouncy;
        //print(bouncy.bounciness);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Calculate()
    {
        //print("Calculated");
        //print(GameObject.FindWithTag("Player").transform.position.y);
        float distance = Mathf.Abs(GameObject.FindWithTag("Player").transform.position.y - transform.position.y);
        //print(distance);
        float multiplier = (additive + distance) / distance;
        //print(multiplier);
        bouncy.bounciness = multiplier;
    }
}
