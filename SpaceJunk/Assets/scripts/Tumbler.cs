using UnityEngine;
using System.Collections;

public class Tumbler : MonoBehaviour {

	public float tumble;
	private Rigidbody2D rigid;

	void Start () {

		rigid = GetComponent<Rigidbody2D>();
		Quaternion randomRotation = Random.rotation;
		float rotation = randomRotation.x;
		rigid.AddTorque(rotation * tumble);
	
	}

}
