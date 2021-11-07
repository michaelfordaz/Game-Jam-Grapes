using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailScript : MonoBehaviour
{
    public Transform player;
    public float zOffset;
    public float yOffset;
    public float xOffset;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.position.x - xOffset, player.position.y - yOffset, zOffset);
    }
}
