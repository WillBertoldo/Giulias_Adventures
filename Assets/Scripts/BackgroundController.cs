using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour {
	private Material CurrentMaterial;
	public float speed;
	private float offset;
	public BoxCollider2D playerBC ;

	void Start () 
	{
		CurrentMaterial = GetComponent<Renderer> ().material;
	}
	
	void Update () 
	{
		offset += 0.001f*Time.deltaTime;
		CurrentMaterial.SetTextureOffset ("_MainTex", new Vector2(offset*speed,0));
		if (playerBC==false)
		{
			offset += 0.000f*Time.deltaTime;
		}
		}
}
