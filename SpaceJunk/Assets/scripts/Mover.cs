using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	public float speed;

	void Start () {
		Debug.Log("transform.forward : " + transform.forward + " speed: " + speed);
		GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
	}

}
