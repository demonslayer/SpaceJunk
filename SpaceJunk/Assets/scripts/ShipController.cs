using UnityEngine;
using System.Collections;

public class ShipController : MonoBehaviour {

	public float speed;

	void FixedUpdate() {
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		Rigidbody2D rigidBody = GetComponent<Rigidbody2D>();
		
		Vector2 movement = new Vector2(moveHorizontal, moveVertical);

		rigidBody.velocity = movement * speed;

	}
}
