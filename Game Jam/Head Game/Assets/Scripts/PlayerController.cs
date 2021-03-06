using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D m_Rigidbody;
    public float m_Thrust = 20f;

    public float horizontalInput;
    public bool touchingGround;

    public GameObject trailObject;

    public AudioSource squishSound;
    public AudioSource splatSound;
    // A rat sqweak when you hit it
    //public AudioSource ratSound;
    // If it's the first splat, don't play the noise
    private bool firstSplat = true;

    public Transform respawnPoint;

    // These are references to images on the canvas
    // They will be used to fade in and out
    public Image black;
    public Image fadeOne;
    public Image fadeTwo;

    // This brings up a menu at the end of the game
    public GameObject endMenuUI;

    void Start()
    {
        // Check to make sure the fades have been set
        if (black != null)
        {
            black.canvasRenderer.SetAlpha(1.0f);
            // Fade from black at beginning
            black.CrossFadeAlpha(0, 3, false);
        }
        if (fadeOne != null)
        {
            fadeOne.canvasRenderer.SetAlpha(0.0f);
        }
        if (fadeTwo != null)
        {
            fadeTwo.canvasRenderer.SetAlpha(0.0f);
        }

        //Fetch the Rigidbody from the GameObject with this script attached
        m_Rigidbody = GetComponent<Rigidbody2D>();
        touchingGround = false;
        trailObject.GetComponent<TrailRenderer>().emitting = false;

        squishSound.Play();
        squishSound.loop = true; //starts playing the squishSound.
        squishSound.mute = true; //mutes the squishSound
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");          
    }

    void FixedUpdate()
    {
        m_Rigidbody.AddForce(new Vector3(horizontalInput, 0.0f, 0) * m_Thrust);
    }

    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!splatSound.isPlaying && firstSplat == false)
        {
            splatSound.Play();
        }
        // Make sure that the head doesn't splat the first time (when game loads). It's annoying.
        if (firstSplat == true && !collision.gameObject.CompareTag("Jar"))
        {
            firstSplat = false;
        }
    }
    

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            trailObject.GetComponent<TrailRenderer>().emitting = true;
            touchingGround = true;
            squishSound.mute = false; //mutes the squishSound
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            trailObject.GetComponent<TrailRenderer>().emitting = false;
            touchingGround = false;
            squishSound.mute = true; //mutes the squishSound
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        /*if (collision.gameObject.CompareTag("Rat"))
        {
            // Play rat noise
            if (!ratSound.isPlaying)
            {
                ratSound.Play();
            }
            gameObject.GetComponent<PlayerController>().trailObject.GetComponent<TrailRenderer>().emitting = false;
            gameObject.GetComponent<PlayerController>().touchingGround = false;
            gameObject.GetComponent<PlayerController>().squishSound.mute = true;

            gameObject.transform.position = respawnPoint.position;
            gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            gameObject.GetComponent<Rigidbody2D>().angularVelocity = 0f;
        }*/
        if (collision.gameObject.CompareTag("End Space"))
        {
            StartCoroutine(fader());
        }

        // If the head hits one of the sides of the jar, trigger splat noise
        if (collision.gameObject.CompareTag("JarTriggerWall") && !splatSound.isPlaying && firstSplat == false)
        {
            splatSound.Play();
        }
    }

    IEnumerator fader()
    {
        // Trigger end song
        GameObject.Find("Game Manager").GetComponent<AudioManager>().ending();
        // Help make the transition look better by having slightly earlier black transition
        black.CrossFadeAlpha(1, 3, false);
        // Transition into end picture
        fadeOne.CrossFadeAlpha(1, 5, false);
        fadeTwo.CrossFadeAlpha(1, 5, false);

        yield return new WaitForSeconds(3);

        // Stop time
        Time.timeScale = 0f;

        // Not affector by Time.timeScale
        yield return new WaitForSecondsRealtime(17);

        // Bring up the end menu
        endMenuUI.SetActive(true);
        // Stop time
        //Time.timeScale = 0f;
        //SceneManager.LoadScene("LevelDesign");
    }
}
