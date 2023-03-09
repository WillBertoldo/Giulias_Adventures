using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour {

	public string Scene;

	public void OnNextScene () {
		SceneManager.LoadScene(Scene);
	}
	
	public void OnQuit () {
		Application.Quit();

	}
}
