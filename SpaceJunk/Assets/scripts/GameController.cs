using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public float spawnWait;
	public float startWait;

	public int enemyCount;

	private bool gameOver;

	private int currentScore;
	public Text scoreText;
	public Text timeText;
	public Canvas gameOverCanvas;
	public Canvas levelClearedCanvas;
	public int maxTime;
	public GameObject ship;
	
	public List<GameObject> enemies;
	
	void Start () {

		gameOverCanvas.gameObject.SetActive(false);
		levelClearedCanvas.gameObject.SetActive(false);

		gameOver = false;

		currentScore = 0;
		UpdateScore(0);

		Vector2 shipPosition = new Vector2(0, -4);
		Instantiate(ship, shipPosition, Quaternion.identity);

		StartCoroutine(Spawn ());
		StartCoroutine(UpdateTime());
	
	}


	public void UpdateScore(int newScore) {
		currentScore += newScore;
		scoreText.text = "Credits: " + currentScore;
	}

	public void EndGame() {
		gameOver = true;
		gameOverCanvas.gameObject.SetActive(true);
	}

	private void ClearLevel() {
		gameOver = true;
		levelClearedCanvas.gameObject.SetActive(true);
	}

	IEnumerator UpdateTime() {

		int timeLeft = maxTime;
		
		while(!gameOver) {
			if (timeLeft <= 0) {
				ClearLevel();
			}

			timeText.text = "Time: " + timeLeft;
			timeLeft--;
			
			yield return new WaitForSeconds(1);
		}

	}

	IEnumerator Spawn() {
		float top = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).y;
		float minX = Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x + 1;
		float maxX = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).x - 1;

		yield return new WaitForSeconds(startWait);

		while (!gameOver) {

			for (int i = 0; i < enemyCount; i++) {
				int RandomEnemy = Random.Range(0, enemies.Count);
				GameObject enemy = enemies[RandomEnemy];

				Vector2 spawnPosition = new Vector2(Random.Range(minX, maxX), top);
				Instantiate(enemy, spawnPosition, Quaternion.identity);
				yield return new WaitForSeconds(spawnWait);
			}

		}
	}
}
