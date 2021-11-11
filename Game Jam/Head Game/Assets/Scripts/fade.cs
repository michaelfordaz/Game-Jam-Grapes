using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class fade : MonoBehaviour
{
    public Image fadeOne;
    public Image fadeTwo;
    public Image fadeThree;
    public Image fadeFour;
    public Image fadeFive;
    public Image fadeSix;
    public Image fadeSeven;

    // Start is called before the first frame update
    void Start()
    {
        // Fade In
        //fadeOne.canvasRenderer.SetAlpha(0.0f);
        // Fade Out
        fadeOne.canvasRenderer.SetAlpha(0.0f);
        fadeTwo.canvasRenderer.SetAlpha(0.0f);
        fadeThree.canvasRenderer.SetAlpha(0.0f);
        fadeFour.canvasRenderer.SetAlpha(0.0f);
        fadeFive.canvasRenderer.SetAlpha(0.0f);
        fadeSix.canvasRenderer.SetAlpha(0.0f);
        fadeSeven.canvasRenderer.SetAlpha(0.0f);
        //fadeIn();
        StartCoroutine(fader());
    }

    // Update is called once per frame
    /*void fadeIn()
    {
        // Fade In
        //fadeOne.CrossFadeAlpha(1, 2, false);
        // Fade Out
        fadeOne.CrossFadeAlpha(0, 5, false);
        //SceneManager.LoadScene("LevelDesign");
    }*/

    IEnumerator fader()
    {
        fadeOne.CrossFadeAlpha(1, 3, false);
        yield return new WaitForSeconds(3);
        fadeOne.CrossFadeAlpha(0, 5, false);
        yield return new WaitForSeconds(5);

        fadeTwo.CrossFadeAlpha(1, 3, false);
        yield return new WaitForSeconds(3);
        fadeTwo.CrossFadeAlpha(0, 5, false);
        yield return new WaitForSeconds(5);

        fadeThree.CrossFadeAlpha(1, 3, false);
        yield return new WaitForSeconds(3);
        fadeThree.CrossFadeAlpha(0, 5, false);
        yield return new WaitForSeconds(5);

        fadeFour.CrossFadeAlpha(1, 3, false);
        yield return new WaitForSeconds(3);
        fadeFour.CrossFadeAlpha(0, 5, false);
        yield return new WaitForSeconds(5);

        fadeFive.CrossFadeAlpha(1, 3, false);
        yield return new WaitForSeconds(3);
        fadeFive.CrossFadeAlpha(0, 5, false);
        yield return new WaitForSeconds(5);

        fadeSix.CrossFadeAlpha(1, 3, false);
        yield return new WaitForSeconds(3);
        fadeSix.CrossFadeAlpha(0, 5, false);
        yield return new WaitForSeconds(5);

        fadeSeven.CrossFadeAlpha(1, 3, false);
        yield return new WaitForSeconds(3);
        fadeSeven.CrossFadeAlpha(0, 5, false);
        yield return new WaitForSeconds(10);

        SceneManager.LoadScene("LevelDesign");
    }
}
