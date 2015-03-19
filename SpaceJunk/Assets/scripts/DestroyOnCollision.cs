using UnityEngine;
using System.Collections;

public class DestroyOnCollision : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log("You are here");
		Destroy(other.gameObject);
		Destroy(gameObject);
	}
}
