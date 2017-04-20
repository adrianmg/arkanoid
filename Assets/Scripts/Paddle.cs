using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour
{
    private float speed = 14.0f;
    private Rigidbody2D rigidBody;
    private Vector2 move;

    private float ppu;
    private float screenWidthUnits;
    private float spriteWidthUnits;
    float boundaryLeft;
    float boundaryRight;


    void Start ()
    {
        rigidBody = gameObject.GetComponent<Rigidbody2D>();

        ppu = gameObject.GetComponent<SpriteRenderer>().sprite.pixelsPerUnit;
        screenWidthUnits = Screen.width / ppu;

        spriteWidthUnits = gameObject.GetComponent<SpriteRenderer>().sprite.bounds.size.x;

        // It's half of width because paddle's pivot is in the center
        boundaryLeft = spriteWidthUnits / 2;
        boundaryRight = screenWidthUnits - (spriteWidthUnits / 2);

        Cursor.lockState = CursorLockMode.Confined;
    }

    void Update()
    {
        CheckKeyboardMovement();

        CheckMouseMovement();
    }

    private void FixedUpdate()
    {
        // @todo: Where do we update the position to prevent glitches and precise collisions? Input is on Update but what about the output? (Mouse wise)

        rigidBody.velocity = move * speed;

        //CheckPaddleLimit();
    }

    void CheckPaddleLimit()
    {
        //Debug.Log(rigidBody.position.x);
    }

    void CheckKeyboardMovement()
    {
        move = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
    }

    void CheckMouseMovement()
    {
        // @todo:   Fix when user stops using keys, the paddle automatically jumps to the mouse current position.
        //          Move mouse aligned with X of the paddle when key pressed?
        //          Detect previous Mouse position? If it's same do nothing?
        if (Input.anyKey == false)
        {
            float mousePositionInUnits = (Input.mousePosition.x / Screen.width) * screenWidthUnits;
            mousePositionInUnits = Mathf.Clamp(mousePositionInUnits, boundaryLeft, boundaryRight);

            rigidBody.position = new Vector2(mousePositionInUnits, rigidBody.position.y);

            Debug.Log("Mouse: " + mousePositionInUnits);
            Debug.Log("Paddle X:" + rigidBody.transform.position.x);
            Debug.Log("RigidBody X:" + rigidBody.position.x);
        }
    }
}
