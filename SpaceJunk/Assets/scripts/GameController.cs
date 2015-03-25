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
	public Canvas gameOverCanvas;

	void Start () {

		Debug.Log("About to make panel invisible");
		gameOverCanvas.gameObject.SetActive(false);

		gameOver = false;
		currentScore = 0;
		UpdateScore(0);

		StartCoroutine(Spawn ());
	
	}

	public void UpdateScore(int newScore) {
		currentScore += newScore;
		scoreText.text = "Score: " + currentScore;
	}

	public void EndGame() {
		gameOver = true;
		gameOverCanvas.gameObject.SetActive(true);
	}

	IEnumerator Spawn() {
		float top = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).y;
		float minX = Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x + 1;
		float maxX = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).x - 1;

		yield return new WaitForSeconds(startWait);

		while (!gameOver) {

			for (int i = 0; i < enemyCount; i++) {
				Vector2 spawnPosition = new Vector2(Random.Range(minX, maxX), top);
				Instantiate(enemy, spawnPosition, Quaternion.identity);
				yield return new WaitForSeconds(spawnWait);
			}

		}

		Debug.Log("the game is over");

	}
}
