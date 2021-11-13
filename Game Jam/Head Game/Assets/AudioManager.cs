using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource primarySong;
    public AudioSource endSong;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ending()
    {
        // Stop playing primary song and start end song
        primarySong.Stop();
        endSong.Play();
    }
}
