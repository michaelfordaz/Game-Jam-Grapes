using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkScript : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(doBlink());
    }

    IEnumerator doBlink()
    {
        // Randomize when head blinks
        yield return new WaitForSeconds(Random.Range(10.0f, 50.0f));
        // Have head blink
        GetComponent<Animator>().SetTrigger("DoBlink");
        StartCoroutine(doBlink());
    }
}
