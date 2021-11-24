using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blood_properties : MonoBehaviour
{
    private SpriteRenderer rend;
    // Store all of the different blood assets
    public Sprite[] blood;
    // This will hold the value of our alpha
    float newAlpha = 1.0f;
    // This will hold the value of how red the blood is
    float newRed = 1.0f;

    void Start()
    {
        // Pick a random blood asset
        rend = GetComponent<SpriteRenderer>();
        int rand = Random.Range(0, blood.Length);
        rend.sprite = blood[rand];
    }

    void Update()
    {
        /*// Blood disappears after 120 seconds
        newAlpha -= Time.deltaTime / 120;
        if (newAlpha < 0)
        {
            Destroy(gameObject);
        }
        Color tmp = rend.color;
        tmp.a = newAlpha;
        rend.color = tmp;*/

        if (newAlpha > 0.5f)
        {
            newAlpha -= Time.deltaTime / 60;
            Color tmp = rend.color;
            tmp.a = newAlpha;
            rend.color = tmp;
        }

        // Blood turns a darker red (dries up) over 60 seconds
        /*if (newRed > 0.5f)
        {
            newRed -= Time.deltaTime / 60;
            Color tmpTwo = rend.color;
            tmpTwo.r = newRed;
            rend.color = tmpTwo;
        }
        else if (newRed < 0.75f)
        {
            rend.sortingOrder = 8;
        }*/
    }

    // Size of the blood splatter
    // Based on the x or y velocity (whichever one is greater) upon impact
    public void createScale(float multiplier)
    {
        // Calculate blood size
        float bloodScale = Random.Range(5.5f + multiplier / 10f, 7.0f + multiplier / 10f);
        // Set blood size
        transform.localScale = new Vector3(bloodScale, bloodScale, bloodScale);
    }
}
