using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class New_Patrol : MonoBehaviour
{
    public float speed;
    private float waitTime;
    public float startWaitTime;

    public Transform[] moveSpots;
    private int currentSpot;

    void Start()
    {
        waitTime = startWaitTime;
        currentSpot = 0;
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[currentSpot].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpots[currentSpot].position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                if (currentSpot == 0)
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    waitTime = startWaitTime;
                    currentSpot = 1;
                }
                else
                {
                    transform.eulerAngles = new Vector3(0, 180, 0);
                    waitTime = startWaitTime;
                    currentSpot = 0;
                }
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
}
