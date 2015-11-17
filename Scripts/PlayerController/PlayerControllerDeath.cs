using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerControllerDeath : MonoBehaviour {
	
	public float t;
	public float gra;
	public float ang;
	public float angle = 10;
	
	//public float slidingTimeLeft = 0f; //スライディング実行時間残
	//private AudioSource sound01;
	
	Transform transform;

	Rigidbody2D rigidbody2D;
	BoxCollider2D box;
	float velocityX;
	float velocityY;
	
	Animator animator;

	bool isGrounded;
	bool isRunning;
	bool isJumping;
	bool isFalling;

	bool isDamaged;

	Score score;

	// Use this for initialization
	void Start () {
		rigidbody2D = GetComponent<Rigidbody2D>();
		animator = GetComponent < Animator > ();
		box = GetComponent<BoxCollider2D> ();
		transform = GetComponent<Transform>();
		score = FindObjectOfType<Score> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (isDamaged == true) {
			t += Time.deltaTime;
		}
		if (t >= 0.1f) {
			box.isTrigger = true;
			float gravity = Mathf.Abs(Physics.gravity.y) * rigidbody2D.gravityScale;
			float direction = angle * Mathf.Deg2Rad;
			float sin = Mathf.Sin (direction);
			float cos = Mathf.Cos (direction);
			float speed = Mathf.Sqrt ((gravity * gra) / (15.0f * sin * cos)) * ang; // forceは係数
			rigidbody2D.AddForce (new Vector2(Mathf.Cos(direction) * speed, Mathf.Sin(direction) * speed));
		}
		if (t >= 3f) {
			score.Save();
			Application.LoadLevel("GameOver");
		}
	}
	
	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "DamageObject") {
			isDamaged = true;
		}
	}
	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Car") {
			isDamaged = true;
		}
    }
}