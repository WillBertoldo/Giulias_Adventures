using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawnController : MonoBehaviour {

	public GameObject cloud;
	public float interval,heightMin,heightMax,widthMax,widthMin,AltitudeMax,AltitudeMin,xPos,zPos;
	private float width,height,Altitude,timeInterval;

		// Use this for initialization
		void Start (){
			timeInterval = 1;
		}
		// Update is called once per frame
		void Update (){
		timeInterval += Time.deltaTime;
		if (timeInterval >= interval){
				spawnObject();
			}
		}

		public void spawnObject(){
			height  = Random.Range (heightMin,heightMax);
			Altitude = Random.Range (AltitudeMin,AltitudeMax);
			width = Random.Range (widthMin,widthMax);
			GameObject tempCCloud1 = Instantiate (cloud) as GameObject;
			cloud.transform.position = new Vector3 (xPos, Altitude,zPos);
			cloud.transform.localScale = new Vector2 (width,height);
			timeInterval = 0;
		}
	}

