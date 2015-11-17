using UnityEngine;
using System.Collections;

public class DamageObjectTakio : MonoBehaviour {

	private AudioSource sound01;
	private AudioSource sound02;
	GameObject scoreGUI;
	Rigidbody2D rigidbody2D;
	PolygonCollider2D polygon;
	public SpriteRenderer sp;
	
	float t;
	public float dropPoint = -50f;
	bool isAttack;
	Animator animator;

	SpriteRenderer MainSpriteRenderer;
	// publicで宣言し、inspectorで設定可能にする
	public Sprite AttackSprite;

	public float gra = 800f;
	public float ang = 800f;

	GameObject collisionsound;

	void Start(){
		scoreGUI = GameObject.Find ("ScoreGUI");
		sound01 = GetComponent<AudioSource> ();
		rigidbody2D = GetComponent<Rigidbody2D>();
		polygon = GetComponent<PolygonCollider2D> ();
		animator = GetComponent<Animator> ();
		sp = GetComponent<SpriteRenderer> ();
		t = 1;
		collisionsound = GameObject.Find("CollisionSound");
		sound02 = collisionsound.GetComponent<AudioSource> ();
	}

	void FixedUpdate(){
		t += Time.deltaTime;
		if (t >= 4f) {
			polygon.isTrigger = (true);
		}
	}
	

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Player") {
			sp.sprite = AttackSprite;
			sound01.Play ();
			sp.color = Color.white;
		}
	}
	void OnTriggerEnter2D(Collider2D col){
			if (col.gameObject.tag == "Car") {
			sound02.Play();
			polygon.enabled = false;
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

