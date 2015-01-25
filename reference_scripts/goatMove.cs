using UnityEngine;
using System.Collections;

public class goatMove : MonoBehaviour {

	public string moveAxis = "Horizontal";
	public string jumpAxis = "Vertical";

	public float jumpSpeed = 1000.0f;
	public float speed = 10.0f;
	public Rigidbody2D myRigidBody;
	
	void FixedUpdate(){
		float axis = Input.GetAxis (moveAxis);
		Vector2 moveVector = Vector2.right * axis * speed * Time.deltaTime;

		myRigidBody.AddForce (moveVector);

		float jumpValue = Input.GetAxis (jumpAxis);
		if (jumpValue > 0.0f) {
			myRigidBody.AddForce(Vector2.up * jumpSpeed * Time.deltaTime);		
		}
	}
}
