using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour
{
    private float speed = 240.0f;
    private Rigidbody2D ballRigidBody;
    private float velocity;

    private float boundaryLeft;
    private float boundaryRight;

    private float mousePosition;
    private bool isMouseMoving = false;



    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Start()
    {
        ballRigidBody = GetComponent<Rigidbody2D>();

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = false;
        mousePosition = GetMousePosition();

        // Boundaries of the screen
        float paddleWidth = GetComponent<SpriteRenderer>().bounds.size.x;
        float screenWidth = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
        boundaryRight = screenWidth - paddleWidth / 2;
        boundaryLeft = (screenWidth - paddleWidth / 2) * -1;
    }

    private void Update()
    {
        UpdateMovementInput();
    }

    private void FixedUpdate()
    {
        MovePaddle();
    }



    private void UpdateMovementInput()
    {
        if (IsMouseMoving()) // Mouse
        {
            velocity = GetMousePosition();
            isMouseMoving = true;
        }
        else // Keyboard
        {
            velocity = Input.GetAxisRaw("Horizontal") * speed;
            isMouseMoving = false;
        }
    }

    private void MovePaddle()
    {
        Vector2 newPosition;
        newPosition.y = ballRigidBody.position.y;

        if (isMouseMoving) // Mouse
        {
            newPosition.x = Mathf.Clamp(velocity, boundaryLeft, boundaryRight);
        }
        else // Keyboard
        {
            velocity = velocity * Time.fixedDeltaTime;
            newPosition.x = Mathf.Clamp(ballRigidBody.position.x + velocity, boundaryLeft, boundaryRight);
        }

        ballRigidBody.MovePosition(newPosition);
    }

    private bool IsMouseMoving()
    {
        float mousePreviousPosition = mousePosition;
        mousePosition = GetMousePosition();

        if (mousePosition - mousePreviousPosition == 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    private float GetMousePosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
    }
}