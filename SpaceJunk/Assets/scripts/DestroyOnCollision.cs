using UnityEngine;
using System.Collections;

public class DestroyOnCollision : MonoBehaviour {

	public GameObject explosion;
	public GameObject playerExplosion;

	void OnTriggerEnter2D(Collider2D other) {

		Instantiate(explosion, transform.position, transform.rotation);

		if (other.tag == "Player") {
			Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
		}

		Destroy(other.gameObject);
		Destroy(gameObject);

	}
}
