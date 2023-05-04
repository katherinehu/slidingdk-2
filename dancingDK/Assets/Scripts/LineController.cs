using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    public float speed;
    private Vector3 dir;
    List<Transform> growth = new List<Transform>();
    public GameObject shadowPrefab;
    private AudioSource backgroundMusic;
    private Rigidbody rbd;
    public static bool startAgain = false;
    public static bool canEnd = false;
    public Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        backgroundMusic = GetComponent<AudioSource>();
        rbd = GetComponent<Rigidbody>();
        growth.Add(transform);
        startAgain = false;
    }

    void LineGrow()
    {
        Transform p = growth[growth.Count-1];
        Instantiate(shadowPrefab, p.position, p.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            canEnd = true;
            // start moving and play music
            if (dir == Vector3.zero)
            {
                dir = Vector3.forward;
                backgroundMusic.Play();
            }
            // if moving left move right
            else if (dir == Vector3.forward)
            {
                dir = Vector3.right;
            }
            // if moving right move left
            else if (dir == Vector3.right)
            {
                dir = Vector3.forward;
            }

        }
        else if (PauseMenu.isPaused == true) {
            print("PAUSE = true");
            backgroundMusic.Pause();
            startAgain = false;
        }
        else if (startAgain == true) {
            print("START AGAIN");
            backgroundMusic.Play();
            startAgain = false;
        }
        // Check if the music has ended
        if (!backgroundMusic.isPlaying && canEnd)
        {
            mainCamera.enabled = false;
            // Do something when the music has ended
            Debug.Log("The music has ended!");
        }
        float movement = speed * Time.deltaTime;
        transform.Translate(dir * movement);
    }
    
    // TODO: add colliders on furniture
    void OnCollisionEnter(Collision collision)
    {
        rbd.velocity = Vector3.zero;
        // display menu
    }
}