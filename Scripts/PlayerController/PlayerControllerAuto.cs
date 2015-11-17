using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerControllerAuto : MonoBehaviour {

	public float move;
	public float jump = 5f;
	public float yatsu = 50f;

	//public float slide = 3f;
//	public float slidingTime = 1f; //スライディング実行時間
	//public float slidingTimeLeft = 0f; //スライディング実行時間残
	//private AudioSource sound01;
	
	Transform transform;

	Rigidbody2D rigidbody2D;
	float velocityX;
	float velocityY;
	
	Animator animator;

	bool isGrounded;
	bool isRunning;
	bool isJumping;
	bool isFalling;

	bool isSliding;

	float t;

	// Use this for initialization
	void Start () {
		rigidbody2D = GetComponent<Rigidbody2D>();
		animator = GetComponent < Animator > ();

		//sound01 = GetComponent<AudioSource> ();
		transform = GetComponent<Transform>();

		t = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Move ();
	}

	void Update () {

	//	Jump ();
	//	Sliding ();
		MecCheck ();
	}

	void MecCheck(){
		velocityX = rigidbody2D.velocity.x;
		velocityY = rigidbody2D.velocity.y;

		isRunning = Mathf.Abs(velocityX) > 0.01 ? true : false;
		isJumping = velocityY > 0.01 ? true : false;
		isFalling = velocityY < 0 ? true : false;

		// isSliding = slidingTimeLeft > 0 ? true : false;
		
		animator.SetBool("isRunning",isRunning);
		animator.SetBool("isJumping",isJumping);
		animator.SetBool("isFalling",isFalling);
		animator.SetBool("isGrounded",isGrounded);
		animator.SetFloat("Vertical", velocityY);

		//animator.SetBool ("IsSliding", isSliding);		
		//animator.SetFloat ("Slidingtime", slidingtime);
		}

	/*void Sliding(){
		if (isGrounded && !isSliding && CrossPlatformInputManager.GetButtonDown ("Sliding")) {

			isSliding = true;
			slidingTime = 1;

			animator.SetBool ("IsSliding", isSliding);
			transform.Rotate (0, 0, 90);
			//rigidbody2D.AddForce(Vector2.right * slide, ForceMode2D.Impulse);
			rigidbody2D.AddForce(new Vector2(500, 0), ForceMode2D.Impulse);

		}

		if (isSliding) {
			slidingTime -= Time.deltaTime;

			//rigidbody2D.AddForce(Vector2.right * jump);
			

			if(slidingTime < 0){
				//transform.Rotate(0,0,-90);
				transform.rotation = Quaternion.Euler(0,0,0);
				isSliding = false;
				slidingTime = 1;
			}
		}
	}

	void Jump(){
		if (isGrounded && CrossPlatformInputManager.GetButtonDown ("Jump")) {
			isGrounded = false;
			isJumping = true;
			animator.SetBool ("isJumping", isJumping);
			rigidbody2D.AddForce(Vector2.up * jump, ForceMode2D.Impulse);

		}
	}*/

	void Move(){
//		float h = CrossPlatformInputManager.GetAxisRaw ("Horizontal");
//		animator.SetFloat ("Horizontal", h);
//		if (transform.localScale.x > 0 && h < 0 || (transform.localScale.x < 0 && h > 0)) {
//			transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
//		}
//		rigidbody2D.velocity = new Vector2 (h * move, rigidbody2D.velocity.y);

		t += Time.deltaTime ;
		
		if (t >= 4f && t < 5.5f) {
			rigidbody2D.velocity = new Vector2 (1 * move, rigidbody2D.velocity.y);		
		}
		if(t >= 9f){
			if(rigidbody2D.velocity.x >= 0 && t < 9.1f) {
				Debug.Log (rigidbody2D.velocity.x);
				Debug.Log ("move = "+move);
				transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
				rigidbody2D.velocity = Vector2.zero;
//				Debug.Log ("shokika");

				
			}
			rigidbody2D.velocity = new Vector2 (-1 * move, rigidbody2D.velocity.y);
		}
		if (t >= 10.5f) {
			t = 1;
			transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
		}
	}

	void OnCollisionEnter2D(Collision2D col){
	if (col.gameObject.tag == "Ground") {
			isGrounded = true;
			isJumping = false;
			animator.SetBool("isJumping",isJumping);
		}
	}		
	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Yatsu") {
			rigidbody2D.AddForce(Vector2.up * yatsu, ForceMode2D.Impulse);
		}
    }
}

