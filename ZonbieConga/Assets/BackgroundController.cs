using UnityEngine;
using System.Collections;

public class BackgroundController : MonoBehaviour {
	private Transform cameraTransform;
	private float spriteWidth;
	// Use this for initialization
	void Start () {
		cameraTransform = Camera.main.transform;
		SpriteRenderer spriteRenderer = renderer as SpriteRenderer;
		spriteWidth = spriteRenderer.sprite.bounds.size.x;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
