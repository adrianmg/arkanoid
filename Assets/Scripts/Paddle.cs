using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour
{
    private float speed = 16.0f;
    private Rigidbody2D paddleRigidBody;
    private float velocity;

    private float screenWidthUnits;
    private float boundaryLeft;
    private float boundaryRight;

    private float mousePosition;
    private bool isMouseMoving = false;



    void Start()
    {
        paddleRigidBody = gameObject.GetComponent<Rigidbody2D>();

        mousePosition = GetMousePosition();
        Cursor.visible = false;

        // Boundaries of the screen
        float ppu = gameObject.GetComponent<SpriteRenderer>().sprite.pixelsPerUnit;
        screenWidthUnits = Screen.width / ppu;

        float spriteWidthUnits = gameObject.GetComponent<SpriteRenderer>().sprite.bounds.size.x;
        boundaryLeft = spriteWidthUnits / 2;
        boundaryRight = screenWidthUnits - (spriteWidthUnits / 2);
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
        newPosition.y = paddleRigidBody.position.y;

        if (isMouseMoving) // Mouse
        {
            newPosition.x = Mathf.Clamp(velocity, boundaryLeft, boundaryRight);
        }
        else // Keyboard
        {
            velocity = velocity * Time.fixedDeltaTime;
            newPosition.x = Mathf.Clamp(paddleRigidBody.position.x + velocity, boundaryLeft, boundaryRight);
        }

        paddleRigidBody.MovePosition(newPosition);
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
        return (Input.mousePosition.x / Screen.width) * screenWidthUnits;
    }
}