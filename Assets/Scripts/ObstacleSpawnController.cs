//Script created by WILLIAM BERTOLDO
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawnController : MonoBehaviour {

	public GameObject Obj1 ,Obj2, Obj3, Obj4;
	public Transform TransformObj1 ,TransformObj2, TransformObj3, TransformObj4;
	public float heightMinObj1, heightMaxObj1, widthMinObj1, widthMaxObj1, xPosObj1, yPosObj1;
	public float heightMinObj2, heightMaxObj2, widthMinObj2, widthMaxObj2, xPosObj2, yPosObj2;
	public float heightMinObj3, heightMaxObj3, widthMinObj3, widthMaxObj3, xPosObj3, yPosObj3;
	public float heightMinObj4, heightMaxObj4, widthMinObj4, widthMaxObj4, xPosObj4, yPosObj4;
	public float timeInterval,axisZ;
	private float intervalTimer, objWidth, objHeight;
	private int randomizeObj;

		// Use this for initialization
		void Start () 
		{
			intervalTimer = 0;
		}
		// Update is called once per frame
		void Update () {
			intervalTimer += Time.deltaTime;
		if (intervalTimer >= timeInterval){
			randomizeObj = Random.Range (1,5);
			if (randomizeObj == 1) {
				spawnObstacle(heightMinObj1, heightMaxObj1, widthMinObj1, widthMaxObj1, xPosObj1, yPosObj1, Obj1);
				}
			if (randomizeObj == 2) {
				spawnObstacle(heightMinObj2, heightMaxObj2, widthMinObj2, widthMaxObj2, xPosObj2, yPosObj2, Obj2);

				}
			if (randomizeObj == 3) {
				spawnObstacle(heightMinObj3, heightMaxObj3, widthMinObj3, widthMaxObj3, xPosObj3, yPosObj3, Obj3);

				}
			if (randomizeObj == 4) {
				spawnObstacle(heightMinObj4, heightMaxObj4, widthMinObj4, widthMaxObj4, xPosObj4, yPosObj4, Obj4);

				}
			}
		}

		public void  spawnObstacle(float heightMin, float heightMax, float widthMin, float widthMax, float xPos, float yPos, GameObject Obj){
			objHeight = Random.Range (heightMin,heightMax);
			objWidth = Random.Range (widthMin,widthMax);
			TransformObj1.position = new Vector3 (xPos,yPos,axisZ);
			TransformObj1.localScale = new Vector2 (objWidth, objHeight);
			GameObject tempObj = Instantiate (Obj) as GameObject;
			intervalTimer = 0;
		}
	}

