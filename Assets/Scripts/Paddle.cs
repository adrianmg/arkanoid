using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour
{
    private float speed = 14.0f;
    private Rigidbody2D paddleRigidBody;
    private Vector2 paddleMove;
    private float boundaryLeft = 1.5f;
    private float boundaryRight= 21.0f;

    void Start ()
    {
        paddleRigidBody = gameObject.GetComponent<Rigidbody2D>();

        //Cursor.lockState = CursorLockMode.Locked;
        Cursor.lockState = CursorLockMode.Confined;

    }

    void Update()
    {
        // Keys movement
        paddleMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
        // Mouse 'push' movement
        //paddleMove = new Vector2(Input.GetAxisRaw("Mouse X"), 0);
        // Mouse position movement
        //paddleMove = new Vector2(Input.mousePosition.x, 0);

        //Debug.Log(Input.GetAxisRaw("Mouse X"));

        CheckMouseMovement();
    }

    private void FixedUpdate()
    {
        paddleRigidBody.velocity = paddleMove * speed;

        CheckPaddleLimit();
    }

    void CheckPaddleLimit()
    {
        //Debug.Log(paddleRigidBody.position.x);
    }

    void CheckMouseMovement()
    {
        float horizontalUnits = Camera.main.orthographicSize * 2;
        float horizontalUnitsPaddle = Screen.width / 16.0f;

        float mousePositionUnit = (Input.mousePosition.x / Screen.width) * horizontalUnits;
        mousePositionUnit = Mathf.Clamp(mousePositionUnit, 0, horizontalUnits);

        Debug.Log("Scenario tile:" + mousePositionUnit);
        Debug.Log("Paddle tile:" + (Input.mousePosition.x / Screen.width) * horizontalUnitsPaddle);



        float mouseUnitPosition = Input.mousePosition.x / Screen.width * 24;
        mouseUnitPosition = Mathf.Clamp(mouseUnitPosition, boundaryLeft, boundaryRight);

        paddleRigidBody.transform.position = new Vector3(mouseUnitPosition, this.transform.position.y, paddleRigidBody.transform.position.z);
    }
}
