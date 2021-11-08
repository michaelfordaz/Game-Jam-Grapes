using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class fade : MonoBehaviour
{
    public Image fadeOne;

    // Start is called before the first frame update
    void Start()
    {
        // Fade In
        //fadeOne.canvasRenderer.SetAlpha(0.0f);
        // Fade Out
        fadeOne.canvasRenderer.SetAlpha(1.0f);
        fadeIn();
    }

    // Update is called once per frame
    void fadeIn()
    {
        // Fade In
        //fadeOne.CrossFadeAlpha(1, 2, false);
        // Fade Out
        fadeOne.CrossFadeAlpha(0, 5, false);
        SceneManager.LoadScene("LevelDesign");
    }
}
