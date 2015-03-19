using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	public float speed;
	private Rigidbody2D rigid;

	void Start () {
		rigid = GetComponent<Rigidbody2D>();
		rigid.velocity = Vector2.up * speed;
	}
	
}
