using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawnController : MonoBehaviour {
	public GameObject obj;
	public float intervalTime, timerInterval, yMin, yMax;
	private float axisX,axisY;

	// Use this for initialization
	void Start () {
		timerInterval = 0;
	}
	// Update is called once per frame
	void Update () {
		timerInterval += Time.deltaTime;
		if (timerInterval >= intervalTime){
			timerInterval = 0;
			axisY = Random.Range (yMin, yMax);
			obj.transform.position = new Vector3 (20, axisY, obj.transform.position.z);
			GameObject tempObj = Instantiate(obj) as GameObject;
		}
	}
}
