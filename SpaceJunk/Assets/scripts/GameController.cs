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
	public Canvas gameOverCanvas;

	public GameObject firstEnemy;
	public GameObject secondEnemy;
	public GameObject thirdEnemy;
	public GameObject fourthEnemy;
	private List<GameObject> enemies;
	
	void Start () {

		gameOverCanvas.gameObject.SetActive(false);

		gameOver = false;
		currentScore = 0;
		UpdateScore(0);

		StartCoroutine(Spawn ());

		enemies = new List<GameObject>();
		enemies.Add(firstEnemy);
		enemies.Add(secondEnemy);
		enemies.Add(thirdEnemy);
		enemies.Add(fourthEnemy);
	
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

			int spawnRates = 0;
//			for (GameObject enemy in enemies) {
//
//			}

			for (int i = 0; i < enemyCount; i++) {
				int RandomEnemy = Random.Range(0, enemies.Count);
				GameObject enemy = enemies[RandomEnemy];

				Vector2 spawnPosition = new Vector2(Random.Range(minX, maxX), top);
				Instantiate(enemy, spawnPosition, Quaternion.identity);
				yield return new WaitForSeconds(spawnWait);
			}

		}

		Debug.Log("the game is over");

	}
}
