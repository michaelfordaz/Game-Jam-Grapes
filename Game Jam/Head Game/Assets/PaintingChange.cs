using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingChange : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindWithTag("Player").transform.position.x > transform.position.x)
        {
            print("hi");
        }
    }
}
