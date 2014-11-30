using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
	public float speed = -1f;

	// Update is called once per frame
	void Update () {
		rigidbody2D.velocity = new Vector2(0, speed);	
		rigidbody2D.angularVelocity = Random.Range(-200, 200);

	}
}
