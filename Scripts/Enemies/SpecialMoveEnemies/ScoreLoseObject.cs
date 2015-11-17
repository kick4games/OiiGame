using UnityEngine;
using System.Collections;

public class ScoreLoseObject : MonoBehaviour {

	private AudioSource sound01;
	private AudioSource sound02;
	Rigidbody2D rigidbody2D;

	public float gra = 800f;
	public float ang = 800f;

	GameObject scoreGUI;
	float t;
	public float dropTime;
	private float timeleft;
//	bool isRotate;
	public int loseScore;

	Score score2;

	GameObject yamauchi;
	float xtransform;
	float ytransform;
	public float spd;

	PolygonCollider2D polygon;
	bool isAttack;
	SpriteRenderer MainSpriteRenderer;
	public Sprite AttackSprite;
	public SpriteRenderer sp;
	Animator animator;

	GameObject wadavoice;

	void Start(){
		yamauchi = GameObject.Find ("Yamauchi");
		scoreGUI = GameObject.Find ("ScoreGUI");
		wadavoice = GameObject.Find ("WadaVoice");
		sound01 = wadavoice.GetComponent<AudioSource> ();
		score2 = scoreGUI.GetComponent<Score> ();
		polygon = GetComponent<PolygonCollider2D> ();
		sp = GetComponent<SpriteRenderer> ();
		animator = GetComponent<Animator> ();
		sound02 = GameObject.Find ("CollisionSound").GetComponent<AudioSource> ();
		rigidbody2D = GetComponent<Rigidbody2D> ();
		//timeleft = 2f;
		
	}

	void FixedUpdate(){

		loseScore = score2.score / 10; 

		xtransform = yamauchi.transform.position.x;
		ytransform = yamauchi.transform.position.y;
		dropTime += Time.deltaTime;

		transform.position = Vector2.MoveTowards (transform.position, new Vector2 (xtransform, ytransform), spd * dropTime);


		if (dropTime >= 5f) {
			Destroy (gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Player") {
			polygon.isTrigger = (true);
			animator.enabled = false;
			sp.sprite = AttackSprite;
			sound01.Play ();
			sp.color = Color.white;
			scoreGUI.SendMessage("LoseScore", loseScore);
			isAttack = true;
		}
	}
	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
		sound01.Play ();
		scoreGUI.SendMessage ("LoseScore", loseScore);
		}

		if (col.gameObject.tag == "Car") {
			sound02.Play();
			polygon.enabled = false;
			rigidbody2D.gravityScale = 1;
			float angle = 40;
			float gravity = Mathf.Abs(Physics.gravity.y) * rigidbody2D.gravityScale;
			float direction = angle * Mathf.Deg2Rad;
			float sin = Mathf.Sin (direction);
			float cos = Mathf.Cos (direction);
			float speed = Mathf.Sqrt ((gravity * gra) / (15.0f * sin * cos)) * ang; // forceは係数
			rigidbody2D.AddForce (new Vector2(Mathf.Cos(direction) * speed, Mathf.Sin(direction) * speed));
			
		}
	}
}