using UnityEngine;
using System.Collections;

using UnityEngine;
using System.Collections;

public class Haruno : MonoBehaviour {
	
	bool isAwake;
	public bool isUp;
	float t;
	float t2;
	float destroytime;
	GameObject yamauchi;
	GameObject harunovoice;
	CircleCollider2D collider;

	SpriteRenderer sp;
	AudioSource sound01;
	
	int count;
	public Sprite spr;
	

	void Start(){
		harunovoice = GameObject.Find("HarunoVoice");//.GetComponent<SpriteRenderer>();
		sp = GetComponent<SpriteRenderer> ();
		collider = GetComponent<CircleCollider2D> ();
		sound01 = harunovoice.GetComponent<AudioSource> ();
		
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
				transform.localScale = new Vector2 (transform.localScale.x + (t2 / 30), transform.localScale.y + (t2 / 30));
			}
			if (t2 >= 2f && count == 0) {
				count += 1;
				if (count == 1) {
					sp.sprite = spr;
					sp.sortingOrder = 2;
					transform.localScale = new Vector2 (4, 4);
					sound01.Play ();
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
			collider.enabled = false;
		}
	}
}