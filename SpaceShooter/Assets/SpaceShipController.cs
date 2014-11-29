using UnityEngine;
using System.Collections;

public class SpaceShipController : MonoBehaviour {
	
	public Vector2 speed = new Vector2 (5, 5);
	public GameObject bullet;
	private Vector2 movement;

	public float fireRate = 0.5f;
	private float nextFire = 0.0f;
	
	// Update is called once per frame
	void Update () {
		float inputX = Input.GetAxis ("Horizontal");
		float inputY = Input.GetAxis ("Vertical");
		
		movement = new Vector2(
			speed.x * inputX,
			speed.y * inputY
		);
		if(Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Instantiate (bullet, transform.position, Quaternion.identity);
		}
	}
	
	void FixedUpdate() {
		rigidbody2D.velocity = movement;
	}
}
