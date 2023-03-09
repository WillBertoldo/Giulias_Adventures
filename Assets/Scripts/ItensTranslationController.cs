using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItensTranslationController : MonoBehaviour {

	public float speed, stopPosition, startPosition;
	public float animationTime;
	public string objectType;
	public bool collision;
	public Animator ObjectAnimator;
	public AudioSource audioSource;
	public PolygonCollider2D collider; 

	public SpriteRenderer spriteRenderer;
	
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (startPosition, transform.position.y, transform.position.z);
		startPosition = transform.position.x;
		startPosition += speed * Time.deltaTime;
		if (startPosition <= stopPosition) {
			Destroy (gameObject);	
		}
		if (collision == true) {
			if("Life".CompareTo(objectType) == 0){
				animationTime += Time.deltaTime;
				if (animationTime >= 0.5f) {
					Destroy (gameObject);
				}
			}
			else{
				Destroy (spriteRenderer);
			}  
		}
	}
	void OnTriggerEnter2D(Collider2D Object){
		Destroy (collider);
		if (Object.CompareTag ("Player")) {
			collision = true;
			if(ObjectAnimator != null){
				ObjectAnimator.SetBool("collision", collision);
			}
			audioSource.Play();
		}
	}
}
