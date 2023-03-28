using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    public float speed;
    private Vector3 dir;
    List<Transform> growth = new List<Transform>();
    public GameObject shadowPrefab;

    // Start is called before the first frame update
    void Start()
    {
        dir = Vector3.forward;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            // if moving right move left
            if (dir == Vector3.forward)
            {
                dir = Vector3.right;
            }
            else if (dir == Vector3.right) // if moving left move right
            {
                dir = Vector3.forward;
            }
        }

        float movement = speed * Time.deltaTime;
        transform.Translate(dir * movement);
    }
}
