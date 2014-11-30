using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
	public float speed = -1f;

	// Update is called once per frame
	void Update () {
		rigidbody2D.velocity = new Vector2(0, speed);	
		rigidbody2D.angularVelocity = Random.Range(-200, 200);

	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.name == "bullet(Clone)") {
			Destroy(gameObject);
			Destroy(other.gameObject);
		} else if (other.name == "spaceship") {
			Destroy(gameObject);
		}
	}

}
