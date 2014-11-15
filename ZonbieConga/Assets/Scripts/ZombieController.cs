using UnityEngine;
using System.Collections;

public class ZombieController : MonoBehaviour {
	[SerializeField]
	private PolygonCollider2D[] colliders;
	private int currentColliderIndex = 0;


	public float moveSpeed;
	public float turnSpeed;
	private Vector3 moveDirection;
	// Use this for initialization
	void Start () {
		moveDirection = Vector3.right;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 currentPosition = transform.position;
		if(Input.GetButton("Fire1")) {
			Vector3 moveToward = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			moveDirection = moveToward - currentPosition;
			moveDirection.z = 0;
			moveDirection.Normalize();
		}
		Vector3 target = moveDirection * moveSpeed + currentPosition;
		transform.position = Vector3.Lerp (currentPosition, target, Time.deltaTime);
		float targetAngle = Mathf.Atan2 (moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Slerp (transform.rotation, 
		                                      Quaternion.Euler (0, 0, targetAngle),
		                                      turnSpeed * Time.deltaTime);
	}

	void SetColliderForSprite(int spriteNum)
	{
		colliders [currentColliderIndex].enabled = false;
		currentColliderIndex = spriteNum;
		colliders [currentColliderIndex].enabled = true;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log ("Hit " + other.gameObject);
	}
}
