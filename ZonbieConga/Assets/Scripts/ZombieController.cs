using UnityEngine;
using System.Collections;
using System.Collections.Generic; // needed?

public class ZombieController : MonoBehaviour {
	[SerializeField]
	private PolygonCollider2D[] colliders;
	private int currentColliderIndex = 0;
	
	public float moveSpeed;
	public float turnSpeed;
	private Vector3 moveDirection;

	private List<Transform> congaLine = new List<Transform>();

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
		EnforceBounds ();
	}

	void SetColliderForSprite(int spriteNum)
	{
		colliders [currentColliderIndex].enabled = false;
		currentColliderIndex = spriteNum;
		colliders [currentColliderIndex].enabled = true;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.CompareTag("cat")) {
			Transform followTarget = congaLine.Count == 0 ? transform : congaLine[congaLine.Count-1];
			Debug.Log(congaLine.Count);
			other.GetComponent<CatController>().JoinConga( followTarget, moveSpeed, turnSpeed );
			congaLine.Add(other.transform);
		} else if (other.CompareTag("enemy")) {
			Debug.Log("Pardon me, ma'am");
		}
	}
	
	private void EnforceBounds()
	{
		Vector3 newPosition = transform.position;
		Camera mainCamera = Camera.main;
		Vector3 cameraPosition = mainCamera.transform.position;

		float xDist = mainCamera.aspect * mainCamera.orthographicSize;
		float xMax = cameraPosition.x + xDist;
		float xMin = cameraPosition.x - xDist;

		if(newPosition.x < xMin || newPosition.x > xMax ){
			newPosition.x = Mathf.Clamp(newPosition.x, xMin, xMax);
			moveDirection.x = -moveDirection.x;
		}

		float yDist = mainCamera.orthographicSize;
		float yMax = cameraPosition.y + yDist;
		float yMin = cameraPosition.y - yDist;

		if(newPosition.y < yMin || newPosition.y > yMax) {
			newPosition.y = Mathf.Clamp(newPosition.y, yMin, yMax);
			moveDirection.y = -moveDirection.y;
		}
		transform.position = newPosition;
	}
}
