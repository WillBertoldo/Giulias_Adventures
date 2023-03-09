using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GiuliaController : MonoBehaviour {

	public static int points;
	public int life;
    public float jumpForce, rollTime, canRoll, endTime;
	public bool roll, amIOnTheGround,death, GamerOverB;
	public Animator animatorController;
	public Rigidbody2D rBGiulia;
	public LayerMask ground;
	public Transform groundVerify, playerCollider;
	public GameObject player;
	public Text lifeT,pointsT;


	// Use this for initialization
	void Start () {
		life = 4;
		points = 0;
	}
    // Update is called once per frame
    void Update() {
        Jump();
        Roll();
        Life();
    }


	void OnTriggerExit2D(Collider2D player){
		if (player.CompareTag("Obstacle")){
            death = true;
        }
    
        if (player.CompareTag ("TenPoints")) {
			points+=10;
		}
		if (player.CompareTag ("OnePoint")) {
			points += 1;
		}
	if (player.CompareTag ("Life")) {
			life+=1;
		}
	}

    public void Roll(){
        if (Input.GetButtonDown("Roll") & (amIOnTheGround == true)) {
            roll = true;
        }
        if (roll == true)
        {
            playerCollider.localPosition = new Vector2(0, -0.6f);
            playerCollider.localScale = new Vector2(3, 3);
            canRoll += Time.deltaTime;
            if (canRoll >= rollTime)
            {
                roll = false;
                canRoll = 0;
            }
        }
        if (roll == false)
        {
            playerCollider.localPosition = new Vector2(0, 0);
            playerCollider.localScale = new Vector2(2, 7);
        }
        animatorController.SetBool("roll", roll==true);
    }

    public void Jump(){
            amIOnTheGround = Physics2D.OverlapCircle(groundVerify.position, 0.00001f, ground);
			if ((Input.GetButtonDown("Jump")) & (amIOnTheGround == true)) {
            jumpForce += Time.deltaTime;
            rBGiulia.AddForce(new Vector2(0, jumpForce));
            roll = false;
		}
        
        animatorController.SetBool("jump", !amIOnTheGround);
    }

    public void Life(){
        lifeT.text = life.ToString();
        pointsT.text = points.ToString();
        if (life < 1) {
            DestroyPlayer();
		}
        if ((death == true) & (life >= 1)){
            endTime += Time.deltaTime;
        }
        if (endTime >= 0.5){
            OnPlayerRestart();
        }
        animatorController.SetBool("death", death);
    }

    public void OnPlayerRestart(){
        life += -1;
        death = false;
        endTime = 0;
        if (death==false){
                DontDestroyOnLoad(player);
          player.transform.position = new Vector2(-10.62f, 0);
        }
    }

    public void DestroyPlayer(){
        	Destroy (player);
			GamerOverB = true;
			if (GamerOverB == true) {
				Application.LoadLevel ("GameOver");
			}
    }

}


