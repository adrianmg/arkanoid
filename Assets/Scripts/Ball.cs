using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    private float speed = 12.5f;
    private Rigidbody2D ballRigidBody;
    private bool isActive = false;
    private float previousPosition;

    private Paddle paddle;
    private float paddlePreviousPosition;


    private void Start()
    {
        ballRigidBody = GetComponent<Rigidbody2D>();

        paddle = FindObjectOfType<Paddle>();
        paddlePreviousPosition = paddle.transform.position.x;
    }

    private void Update()
    {
        if (!isActive)
        {
            this.transform.position = new Vector3(paddle.transform.position.x, this.transform.position.y, this.transform.position.z);

            if (Input.GetButtonDown("Fire1"))
            {
                LaunchBall();
            }
            else
            {
                paddlePreviousPosition = paddle.transform.position.x;
            }
        }
    }

    void LaunchBall()
    {
        if (paddle.transform.position.x - paddlePreviousPosition >= 0)
        {
            ballRigidBody.velocity = new Vector2(speed / 2 , speed);
        }
        else
        {
            ballRigidBody.velocity = new Vector2(-speed / 2, speed);
        }          

        isActive = true;
    }
}
