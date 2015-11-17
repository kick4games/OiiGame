using UnityEngine;
using System.Collections;

public class Takuya : MonoBehaviour {

	private AudioSource sound01;
	GameObject scoreGUI;
	Rigidbody2D rigidbody2D;
	PolygonCollider2D polygon;
	SpriteRenderer sp;
	
	float t;
	float t2;
	bool isTouched;

	SpriteRenderer MainSpriteRenderer;
	// publicで宣言し、inspectorで設定可能にする
	public Sprite Sprite;


	void Start(){
		scoreGUI = GameObject.Find ("ScoreGUI");
		sound01 = GetComponent<AudioSource> ();
		rigidbody2D = GetComponent<Rigidbody2D>();
		polygon = GetComponent<PolygonCollider2D> ();
		sp = GetComponent<SpriteRenderer> ();
	}

	void FixedUpdate(){
		t += Time.deltaTime;
		if (t >= 3f) {
			Destroy(gameObject);
		}
		
		if (isTouched) {
			t = 0;
			polygon.enabled = (false);
			t2 += Time.deltaTime;
			if (t2 >= 7.5f) {
				Destroy(gameObject);
			}
		}
	}
	

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
			sp.sprite = Sprite;
			sound01.Play ();
		}

		if (col.gameObject.tag == "Player") {
			scoreGUI.SendMessage ("AddScore", 1);
		}

		if (col.gameObject.tag == "Player") {
			isTouched = true;
		//animator.SetBool("isAttack",isAttack);
	 }
	}
}

