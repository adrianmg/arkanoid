using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour
{
    private float           speed = 14.0f;
    private Rigidbody2D     paddleRigidBody;
    private Vector2         paddleMove;

    void Start ()
    {
        paddleRigidBody = gameObject.GetComponent<Rigidbody2D>();
	}

    void Update()
    {
        // Keys movement
        paddleMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
        // Mouse 'push' movement
        //paddleMove = new Vector2(Input.GetAxisRaw("Mouse X"), 0);
        // Mouse position movement
        //paddleMove = new Vector2(Input.mousePosition.x, 0);

        Debug.Log(Input.GetAxisRaw("Mouse X"));
        Debug.Log(Input.mousePosition.x);
    }

    private void FixedUpdate()
    {
        paddleRigidBody.velocity = paddleMove * speed;

        CheckPaddleLimit();
    }

    void CheckPaddleLimit()
    {
        Debug.Log(paddleRigidBody.position.x);
    }
}
