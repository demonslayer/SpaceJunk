using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	public float speed;
	private Rigidbody2D rigid;

	void Start () {
		rigid = GetComponent<Rigidbody2D>();
		rigid.velocity = Vector2.up * speed;
	}

	void Update () {
		float top = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).y;
		if (rigid.position.y >= top) {
			Destroy(gameObject);
		}
	}

}
