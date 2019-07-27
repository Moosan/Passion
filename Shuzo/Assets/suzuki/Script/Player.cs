using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    public float jump;
    public float speed;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        

        //速度を制限してる
        if ((rb.velocity.x) > speed)
        {
            rb.velocity = Vector3.right * speed + Vector3.up * rb.velocity[1] + Vector3.forward * rb.velocity[2];
        }
        if ((rb.velocity.x) < -speed)
        {
            rb.velocity = Vector3.right * -speed + Vector3.up * rb.velocity[1] + Vector3.forward * rb.velocity[2];
        }

    }

    void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(transform.right * 6);
        }


        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(transform.right * -6);
        }

    }


}