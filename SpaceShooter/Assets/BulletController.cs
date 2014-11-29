using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {
	public float speed = 2;

	// Use this for initialization
	void Start () {
		rigidbody2D.velocity = new Vector2(0, speed);
	}
	
	// Update is called once per frame
	void OnBecameInvisible () {
		Destroy (gameObject);
	}
}
