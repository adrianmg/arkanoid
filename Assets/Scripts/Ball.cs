using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        Debug.Log("Ball velocity " + ballRigidBody.velocity.ToString("F2"));
    }

    private void FixedUpdate()
    {
        if (isActive)
        {
            KeepConstantVelocity();
        }
    }

    private void OnCollisionEnter2D(Collision2D e)
    {
        if (e.gameObject.tag == "Dead")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else if (e.gameObject.tag == "Player")
        {
            BounceAgainstPaddle(e);
        }
    }

    private void LaunchBall()
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

        ballRigidBody.velocity = new Vector2(speedX / 2, speed);

        isActive = true;
    }

    private void KeepConstantVelocity()
    {
        ballRigidBody.velocity = ballRigidBody.velocity.normalized * speed;
    }

    private void BounceAgainstPaddle(Collision2D paddle)
    {
        if (isActive)
        {
            float relative = Mathf.Clamp(this.transform.position.x - paddle.gameObject.transform.position.x, -1, 1);
            Vector2 move = new Vector2(relative, 1);

            ballRigidBody.velocity = move * speed;
        }
    }
}
