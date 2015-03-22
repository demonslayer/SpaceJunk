using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public float spawnWait;
	public float startWait;

	public GameObject enemy;
	public int enemyCount;

	private bool gameOver;
	private int currentScore;
	public Text scoreText;

	void Start () {

		gameOver = false;
		currentScore = 0;
		UpdateScore(0);

		StartCoroutine(Spawn ());
	
	}

	private void UpdateScore(int newScore) {
		currentScore += newScore;
		scoreText.text = "Score: " + currentScore;
	}

	IEnumerator Spawn() {
		float top = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).y;
		float minX = Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x;
		float maxX = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).x;

		yield return new WaitForSeconds(startWait);

		while (!gameOver) {

			for (int i = 0; i < enemyCount; i++) {
				Vector2 spawnPosition = new Vector2(Random.Range(minX, maxX), top);
				Instantiate(enemy, spawnPosition, Quaternion.identity);
				yield return new WaitForSeconds(spawnWait);
			}

		}

	}
}
