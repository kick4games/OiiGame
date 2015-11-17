using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {

	public float move;
	public float jump = 5f;
	public float yatsu = 50f;
	public float spd = 100f;
	public float nspd = 100f;
	public float bspd = 100f;
	public float hspd = 100f;
	
	
	public int heartCount;

	//public float slide = 3f;
	//public float slidingTime = 1f; //スライディング実行時間
	//public float slidingTimeLeft = 0f; //スライディング実行時間残
	//private AudioSource sound01;
	
	Transform transform;

	Rigidbody2D rigidbody2D;
	float velocityX;
	float velocityY;
	
	Animator animator;
	private AudioSource sound01;

	bool isGrounded;
	bool isRunning;
	bool isJumping;
	bool isFalling;

	public bool isNorihiko;
	bool isUp;

	public bool isSakie;

	public bool isBro;
	bool isUpBro;

	public bool isHaruno;
	bool isDown;
	
	public bool isCameraReset;

	public GameObject camera;
	Transform cTransform;
	public float t;
	public float nt;
	public float bt;
	public float ht;
	public float upforce;
	public float upforcebro;
	public float downforce;


	//bool isSliding;

	// Use this for initialization
	void Start () {
		rigidbody2D = GetComponent<Rigidbody2D>();
		animator = GetComponent < Animator > ();
		sound01 = GetComponent<AudioSource> ();
		transform = GetComponent<Transform>();
		camera = GameObject.Find ("Main Camera");
		cTransform = camera.transform;
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Move ();

		if (isSakie) {
			t += Time.deltaTime;

			rigidbody2D.gravityScale = 0;
			transform.position = Vector2.MoveTowards (transform.position, new Vector2 (0, 762), spd);
			cTransform.position = new Vector2 (0, 770);
			//Debug.Log ("kuchu kotei");

			if (t >= 7f) {
				rigidbody2D.gravityScale = 15;
				//cTransform.position = new Vector2 (0, transform.position.y - 1.5f);
				t = 0;
				isSakie = false;

				//if(isSakie == false && transform.position.y <= 2f){
				//Debug.Log ("Recovery");
					
				}
			}

		if (isNorihiko) {
			nt += Time.deltaTime;
			
			rigidbody2D.gravityScale = 0;
			transform.position = Vector2.MoveTowards (transform.position, new Vector2 (0, 533), nspd);
			cTransform.position = new Vector2 (0, 530);

		
			if (nt >= 4f) {
				rigidbody2D.gravityScale = 15;
				//cTransform.position = new Vector2 (0, transform.position.y - 1.5f);
				isUp = true;
				isNorihiko = false;

				}
				//if(isSakie == false && transform.position.y <= 2f){
				//Debug.Log ("Recovery");
			}

		if(isUp){
			rigidbody2D.velocity = new Vector2 (0, 0);
			rigidbody2D.AddForce(Vector2.up * upforce, ForceMode2D.Impulse);
			nt = 0;
			isCameraReset = true;
			isUp = false;
		
		}
		if (isBro) {
			bt += Time.deltaTime;
			
			rigidbody2D.gravityScale = 0;
			transform.position = Vector2.MoveTowards (transform.position, new Vector2 (0, 723), bspd);
			cTransform.position = new Vector2 (0, 720);
			
			
			if (bt >= 4f) {
				rigidbody2D.gravityScale = 15;
				//cTransform.position = new Vector2 (0, transform.position.y - 1.5f);
				isUpBro = true;
				isBro = false;
				
			}
			//if(isSakie == false && transform.position.y <= 2f){
			//Debug.Log ("Recovery");
		}
		
		if(isUpBro){
			rigidbody2D.velocity = new Vector2 (0, 0);
			rigidbody2D.AddForce(Vector2.up * upforcebro, ForceMode2D.Impulse);
			bt = 0;
			isCameraReset = true;
			isUpBro = false;	
		}

		if (isHaruno) {
			ht += Time.deltaTime;
			
			rigidbody2D.gravityScale = 0;
			transform.position = Vector2.MoveTowards (transform.position, new Vector2 (0, 653), hspd);
			cTransform.position = new Vector2 (0, 650);
			
			
			if (ht >= 4f) {
				rigidbody2D.gravityScale = 15;
				//cTransform.position = new Vector2 (0, transform.position.y - 1.5f);
				isDown = true;
				isHaruno = false;
				
			}
			//if(isSakie == false && transform.position.y <= 2f){
			//Debug.Log ("Recovery");
		}
		
		if(isDown){
			rigidbody2D.velocity = new Vector2 (0, 0);
			rigidbody2D.AddForce(-Vector2.up * downforce, ForceMode2D.Impulse);
			ht = 0;
			isCameraReset = true;
			isDown = false;
			
		}

		if (isGrounded) {
			t = 0;				
			isSakie = false;
			//Debug.Log ("Reset");
		}
		if (isCameraReset && isGrounded == false && isSakie == false && isNorihiko == false && isBro == false && isHaruno == false) {
			cTransform.position = new Vector2 (0, transform.position.y + 3);
		} 
		if (isGrounded && isCameraReset) {
			cTransform.position = new Vector2(0, 7);
			isCameraReset = false;
		}
	}

	void Update () {
		Jump ();
		//Sliding ();
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
	}*/

	void Jump(){
		if (isGrounded && CrossPlatformInputManager.GetButtonDown ("Jump")) {
			sound01.Play ();
			isGrounded = false;
			isJumping = true;			
			animator.SetBool ("isJumping", isJumping);
			rigidbody2D.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
		}
	}

	void Move(){
		float h = CrossPlatformInputManager.GetAxisRaw ("Horizontal");
		animator.SetFloat ("Horizontal", h);
		if (transform.localScale.x > 0 && h < 0 || (transform.localScale.x < 0 && h > 0)) {
			transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
		}
		rigidbody2D.velocity = new Vector2 (h * move, rigidbody2D.velocity.y);
	}

	void OnCollisionEnter2D(Collision2D col){
	if (col.gameObject.tag == "Ground") {
			isGrounded = true;
			isJumping = false;
			animator.SetBool("isJumping",isJumping);
		}
	if (col.gameObject.tag == "DamageObject") {
			Destroy (this);
		}
	}	

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Yatsu" && isGrounded == false) {
			rigidbody2D.AddForce (Vector2.up * yatsu, ForceMode2D.Impulse);
			//Debug.Log("Yatsu");
			
		}
		if (col.gameObject.tag == "Sakie") {
			isSakie = true;
		}
		if (col.gameObject.tag == "Norihiko") {
			isNorihiko = true;
		}
		if (col.gameObject.tag == "Bro") {
			isBro = true;
		}
		if (col.gameObject.tag == "Haruno") {
			isHaruno = true;
		}
	}
}