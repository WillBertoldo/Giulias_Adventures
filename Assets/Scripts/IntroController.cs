using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroController : MonoBehaviour {
	public float screenTime;
    public SpriteRenderer spriteRenderer;
    public float backgroundColor, logoSize;
    public GameObject logo;
    public AudioSource audioSource;
    private bool audioPlayed;
   

	// Use this for initialization
	void Start () {
        logo.transform.localScale = new Vector2(0, 0);
        audioPlayed = false;
    }

	// Update is called once per frame
	void Update () {
        startUIChanges();
        screenTime += Time.deltaTime;
        logoSize+=Time.deltaTime/1.3f;
        if (screenTime > 3f){
            playAudio();
            changeToFinalUIProperties();
        }
        if (screenTime > 7f){
			SceneManager.LoadScene ("MainMenu");
		}
        if (Input.anyKeyDown){
			SceneManager.LoadScene ("MainMenu");
        }
    }

    public void startUIChanges(){
        spriteRenderer.color = new Color(0, 0,0);
        logo.transform.localScale = new Vector2(logoSize /3,logoSize /3);
        logo.transform.localRotation = Quaternion.Euler(0, 0, 150 * logoSize);
    }

    public void changeToFinalUIProperties(){
        backgroundColor += Time.deltaTime;
        spriteRenderer.color = new Color(backgroundColor, backgroundColor, backgroundColor);
        logo.transform.localScale = new Vector2(0.83f, 0.83f);
        logo.transform.localRotation = Quaternion.Euler(0, 0,0);
    }

    public void playAudio(){
        if(audioPlayed == false){
            audioSource.Play();
            audioPlayed = true;
        }
    }
}
