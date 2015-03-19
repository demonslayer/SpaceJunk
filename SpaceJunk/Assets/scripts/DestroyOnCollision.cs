using UnityEngine;
using System.Collections;

public class DestroyOnCollision : MonoBehaviour {

	public GameObject explosion;

	void OnTriggerEnter2D(Collider2D other) {

		Instantiate(explosion, transform.position, transform.rotation);

		Destroy(other.gameObject);
		Destroy(gameObject);

	}
}
