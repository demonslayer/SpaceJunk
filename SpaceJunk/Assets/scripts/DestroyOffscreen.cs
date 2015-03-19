using UnityEngine;
using System.Collections;

public class DestroyOffscreen : MonoBehaviour {

	void Update () {
		Rigidbody2D rigid = GetComponent<Rigidbody2D>();
		float top = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).y;
		float bottom = Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y;
		if (rigid.position.y >= top || rigid.position.y <= bottom) {
			Destroy(gameObject);
		}
	}

}
