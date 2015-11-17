using UnityEngine;
using System.Collections;

using UnityEngine;
using System.Collections;

public class Norihiko : MonoBehaviour {
	
	bool isAwake;
	public bool isUp;
	float t;
	float t2;
	float destroytime;
	GameObject yamauchi;
	GameObject norihikovoice1;
	GameObject norihikovoice2;
	GameObject norihikovoice3;
	CircleCollider2D colid;
	
	SpriteRenderer sp;
	AudioSource sound01;
	AudioSource sound02;
	AudioSource sound03;
	Animator animator;
	
	int count;
	int r;
	public Sprite spr;
	

	void Start(){
		norihikovoice1 = GameObject.Find("NorihikoVoice1");//.GetComponent<SpriteRenderer>();
		norihikovoice2 = GameObject.Find("NorihikoVoice2");//.GetComponent<SpriteRenderer>();
		norihikovoice3 = GameObject.Find("NorihikoVoice3");//.GetComponent<SpriteRenderer>();

		animator = GetComponent<Animator> ();
		sp = GetComponent<SpriteRenderer> ();
		colid = GetComponent<CircleCollider2D> ();
		sound01 = norihikovoice1.GetComponent<AudioSource> ();
		sound02 = norihikovoice2.GetComponent<AudioSource> ();
		sound03 = norihikovoice3.GetComponent<AudioSource> ();
		
		yamauchi = GameObject.Find ("Yamauchi");
		count = 0;
		destroytime = 3f;
	}
	
	// Update is called once per frame
	void Update () {
		destroytime -= Time.deltaTime;
		if (destroytime <= 0) {
			Destroy(gameObject);
		}

		if (isAwake) {
			destroytime = 3;
			t2 += Time.deltaTime;
			if (t2 <= 2f) {
				sp.sortingOrder = 2;
				transform.localScale = new Vector2 (transform.localScale.x + (t2 / 45), transform.localScale.y + (t2 / 45));
			}
			if (t2 >= 2f && count == 0) {
				count += 1;
				if (count == 1) {
					animator.enabled = false;
					sp.sprite = spr;
					sp.sortingOrder = 2;
					transform.localScale = new Vector2 (3, 3);
					r = Random.Range (1, 4);
					if (r == 1) {
						sound01.Play ();
					}
					if (r == 2) {
						sound02.Play ();
					}
					if (r == 3) {
						sound03.Play ();
					}
				}
			}
		if(t2 >= 5f){
				Destroy(gameObject);
			}
		}
	}
	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
			isAwake = true;
			colid.enabled = false;
		}
	}
}

