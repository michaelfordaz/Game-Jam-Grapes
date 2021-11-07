using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D m_Rigidbody;
    public float m_Thrust = 20f;

    public float horizontalInput;

    void Start()
    {
        
        //Fetch the Rigidbody from the GameObject with this script attached
        m_Rigidbody = GetComponent<Rigidbody2D>();
        
      
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");          
    }

    void FixedUpdate()
    {
        m_Rigidbody.AddForce(new Vector3(horizontalInput, 0.0f, 0) * m_Thrust);
    }
}
