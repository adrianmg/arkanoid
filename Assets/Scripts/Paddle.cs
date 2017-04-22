using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour
{
    private float speed = 16.0f;
    private Rigidbody2D paddleRigidBody;
    private float velocity;

    private float ppu;
    private float screenWidthUnits;
    private float spriteWidthUnits;
    float boundaryLeft;
    float boundaryRight;


    void Start ()
    {
        paddleRigidBody = gameObject.GetComponent<Rigidbody2D>();
        //movement = paddleRigidBody.transform.position;

        Debug.Log("Initial position: " + paddleRigidBody.position.ToString("F2"));

        ppu = gameObject.GetComponent<SpriteRenderer>().sprite.pixelsPerUnit;
        screenWidthUnits = Screen.width / ppu;

        spriteWidthUnits = gameObject.GetComponent<SpriteRenderer>().sprite.bounds.size.x;

        // It's half of width because paddle's pivot is in the center
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
        velocity += Input.GetAxisRaw("Horizontal") * speed;
        Debug.Log(velocity.ToString("F2"));
    }

    void MovePaddle()
    {
        if (velocity != 0)
        {
            velocity = velocity * Time.fixedDeltaTime;

            Vector2 newPosition;
            newPosition.y = paddleRigidBody.position.y;
            newPosition.x = Mathf.Clamp(paddleRigidBody.position.x + velocity, boundaryLeft, boundaryRight);

            paddleRigidBody.MovePosition(newPosition);

            Debug.Log(newPosition.ToString("F2"));
        }
    }


























    //void CheckMouseMovement()
    //{
    //    // @todo:   Fix when user stops using keys, the paddle automatically jumps to the mouse current position.
    //    //          Move mouse aligned with X of the paddle when key pressed?
    //    //          Detect previous Mouse position? If it's same do nothing?
    //    if (Input.anyKey == false)
    //    {
    //        float mousePositionInUnits = (Input.mousePosition.x / Screen.width) * screenWidthUnits;
    //        mousePositionInUnits = Mathf.Clamp(mousePositionInUnits, boundaryLeft, boundaryRight);

    //        rigidBody.position = new Vector2(mousePositionInUnits, rigidBody.position.y);

    //        Debug.Log("Mouse: " + mousePositionInUnits);
    //        Debug.Log("Paddle X:" + rigidBody.transform.position.x);
    //        Debug.Log("RigidBody X:" + rigidBody.position.x);
    //    }
    //}
}
