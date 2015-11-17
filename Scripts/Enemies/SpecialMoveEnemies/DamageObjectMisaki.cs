using UnityEngine;
using System.Collections;

public class DamageObjectMisaki : MonoBehaviour {

	private AudioSource sound01;
	private AudioSource sound02;
	public float gra = 800f;
	public float ang = 800f;
	
	GameObject scoreGUI;
	GameObject misakivoice;
	Rigidbody2D rigidbody2D;
	PolygonCollider2D polygon;
	public SpriteRenderer sp;
	Transform transform;
	Vector2 pos;
	
	float t;
	public float dropPoint = 10f;
	bool isAttack;

	SpriteRenderer MainSpriteRenderer;
	// publicで宣言し、inspectorで設定可能にする
	public Sprite AttackSprite;

	public float spd;
	public float awaketime;
	bool isFlying;

	void Start(){
		scoreGUI = GameObject.Find ("ScoreGUI");
		misakivoice = GameObject.Find ("MisakiVoice");
		sound01 = misakivoice.GetComponent<AudioSource> ();
		rigidbody2D = GetComponent<Rigidbody2D>();
		polygon = GetComponent<PolygonCollider2D> ();
		transform = GetComponent<Transform> ();
		sp = GetComponent<SpriteRenderer> ();
		isFlying = false;
	    sound02 = GameObject.Find("CollisionSound").GetComponent<AudioSource>();
	}

	void FixedUpdate(){
		t += Time.deltaTime;

		if (t >= 4f && (polygon.isTrigger == true || isFlying == true)) {
			transform.position = Vector2.MoveTowards (transform.position, 
				                     new Vector2 (transform.position.x , transform.position.y + 3), 
				                        spd * awaketime);
			}
			if(transform.position.y >= 0f){
			//rigidbody2D.gravityScale = 1;
			polygon.isTrigger = (false);
			
			}
		if(t >= 7f){
			isFlying = true;
			
		}
		if (transform.position.y >= dropPoint) {
			Destroy(gameObject);
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
			rigidbody2D.gravityScale = 1;
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

