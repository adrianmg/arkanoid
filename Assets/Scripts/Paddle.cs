using UnityEngine;

public class Paddle : MonoBehaviour {

    private Rigidbody2D paddleRigidBody;

    void Start () {

        paddleRigidBody = gameObject.GetComponent<Rigidbody2D>();

        Debug.Log(paddleRigidBody);
		
	}
}
