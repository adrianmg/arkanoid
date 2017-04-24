using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    private float speed = 14.0f;
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

    private void FixedUpdate()
    {
        if (isActive)
        {
            KeepConstantVelocity();
        }
    }

    void LaunchBall()
    {
        float direction = paddle.transform.position.x - paddlePreviousPosition;
        float speedX = speed;

        if(direction < 0)
        {
            speedX = -speed;
        }
        else if(direction == 0) // Stopped? Aim for closest side
        {
            float middleOfScreen = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, 0, 0)).x;

            if (paddle.transform.position.x < middleOfScreen)
            {
                speedX = -speed;
            }
        }

        ballRigidBody.velocity = new Vector2(speedX, speed);

        isActive = true;
    }

    void KeepConstantVelocity()
    {
        ballRigidBody.velocity = ballRigidBody.velocity.normalized * speed;
    }
}
