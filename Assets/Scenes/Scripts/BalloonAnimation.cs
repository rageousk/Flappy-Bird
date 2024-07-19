using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonAnimation : MonoBehaviour
{ 
    //public GameObject balloon;
    public float amplitude = 2.0f;
    public float speed = 0.5f;
    public float speedx;
    private Vector3 start;
    private float starty;
    // Start is called before the first frame update
    void Start()
    {
        start = transform.position;
        starty = transform.position.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        float offsetY = amplitude * Mathf.Sin(Time.time * speed) * Time.deltaTime;
        speedx = -3f * Time.deltaTime;

        Vector3 m = new Vector3(speedx, offsetY, 0);

        transform.Translate(m);

        //transform.position = new Vector3(transform.position.x + movement, transform.position.y, transform.position.z);
        if (transform.position.x < -35.0f)
        {
            transform.position = new Vector3(50f, transform.position.y);
        }
    }
}
