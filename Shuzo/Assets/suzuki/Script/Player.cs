using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
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
        SpeedLimit(speed);

        if (Input.GetKey(KeyCode.D))
        {
            Move(15);
        }


        if (Input.GetKey(KeyCode.A))
        {
            Move(-15);
        }

    }


    public void Move(int power)
    {
        rb.AddForce(transform.right * power);
    }

    public void Angular()
    {
        

    }

    void OnCollisionEnter(Collision other)
    {
        Vector3 normal = Vector3.zero;

        //HN待ち


        
            
    }

    public void SpeedLimit(float limit)
    {
        if ((rb.velocity.x) > limit)
        {
            rb.velocity = Vector3.right * limit + Vector3.up * rb.velocity[1] + Vector3.forward * rb.velocity[2];
        }
        if ((rb.velocity.x) < -limit)
        {
            rb.velocity = Vector3.right * -limit + Vector3.up * rb.velocity[1] + Vector3.forward * rb.velocity[2];
        }
    }

}