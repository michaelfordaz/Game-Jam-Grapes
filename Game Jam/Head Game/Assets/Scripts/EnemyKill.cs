using System.Collections;
using UnityEngine;

public class EnemyKill : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.gameObject.tag == "Player")
       {
            //collision.gameObject.SendMessage("ApplyDamage", 10);
            Debug.Log("You just got fucking DAMAGED bitch");
       }
    }
    
}
