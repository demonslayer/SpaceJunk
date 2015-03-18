using UnityEngine;
using System.Collections;


[System.Serializable]
public class Boundary {
	
	public float xMin, xMax, yMin, yMax;
	
}

public class ShipController : MonoBehaviour {

	public float speed;
	public float fireRate;
	public GameObject shot;
	public Transform shotSpawn;

	private Boundary boundary;
	private float nextFire;

	void Start() {
		Debug.Log (Screen.height);

		Vector3 maxes = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
		Vector3 mins = Camera.main.ScreenToWorldPoint(new Vector3(0, 0));
		Debug.Log("height: " + mins.y + " and width: " + mins.x);

		this.boundary = new Boundary();
		boundary.xMax = maxes.x - 1;
		boundary.yMax = maxes.y - 3;
		boundary.xMin = mins.x + 1;
		boundary.yMin = mins.y + 1;
	}

	void Update() {
		if (Input.GetButton("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
		}
	}

	void FixedUpdate() {
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		Rigidbody2D rigidBody = GetComponent<Rigidbody2D>();
		
		Vector2 movement = new Vector2(moveHorizontal, moveVertical);

		rigidBody.velocity = movement * speed;

		rigidBody.position = new Vector2(
			Mathf.Clamp(rigidBody.position.x, boundary.xMin, boundary.xMax), 
			Mathf.Clamp(rigidBody.position.y, boundary.yMin, boundary.yMax));

	}
}
