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

    // Start is called before the first frame update
    void Start()
    {
        backgroundMusic = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
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

        float movement = speed * Time.deltaTime;
        transform.Translate(dir * movement);
    }
}
