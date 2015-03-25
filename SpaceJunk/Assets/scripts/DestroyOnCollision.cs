using UnityEngine;
using System.Collections;

public class DestroyOnCollision : MonoBehaviour {

	public GameObject explosion;
	public GameObject playerExplosion;

	private int scoreValue;
	private GameController gameController;
	private EnemyProperties enemyProperties;

	void Start() {
		scoreValue = GetComponent<EnemyProperties>().scoreValue;

		GameObject gameControllerObject = GameObject.FindWithTag("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent<GameController>();
		}
		
		if (gameController == null) {
			Debug.Log("Cannot find Game Controller, sorry!");
		}
	}

	void OnTriggerEnter2D(Collider2D other) {

		Instantiate(explosion, transform.position, transform.rotation);

		if (other.tag == "Player") {
			Instantiate(playerExplosion, transform.position, transform.rotation);
			gameController.EndGame();
		}

		gameController.UpdateScore(scoreValue);

		Destroy(other.gameObject);
		Destroy(gameObject);

	}
}
