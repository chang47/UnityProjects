using UnityEngine;
using System.Collections;

public class SpawnController : MonoBehaviour {

	public GameObject enemy;
	public float spawnTime = 2f;
	// Use this for initialization
	void Start () {
		InvokeRepeating ("addEnemy", spawnTime, spawnTime);
	}

	void addEnemy() {
		float x1 = transform.position.x - renderer.bounds.size.x / 2;
		float x2 = transform.position.x + renderer.bounds.size.x / 2;
		Vector2 spawnPoint = new Vector2 (Random.Range (x1, x2), transform.position.y);
		Instantiate (enemy, spawnPoint, Quaternion.identity);
	}

}
