using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour
{
    private float speed = 16.0f;
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
        float screenHorizontalUnits = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
        float spriteHorizontalUnits = GetComponent<SpriteRenderer>().sprite.bounds.size.x;
        boundaryLeft = spriteHorizontalUnits / 2;
        boundaryRight = screenHorizontalUnits - (spriteHorizontalUnits / 2);
    }

    void Update()
    {
        UpdateMovementInput();
    }

    private void FixedUpdate()
    {
        MovePaddle();
    }



    void UpdateMovementInput()
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

    void MovePaddle()
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

    bool IsMouseMoving()
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

    float GetMousePosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
    }
}