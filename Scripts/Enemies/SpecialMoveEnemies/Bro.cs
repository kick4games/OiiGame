using UnityEngine;
using System.Collections;

using UnityEngine;
using System.Collections;

public class Bro : MonoBehaviour {
	
	bool isAwake;
	public bool isUp;
	float t;
	float t2;
	float destroytime;
	GameObject yamauchi;
	GameObject brothervoice;
	CircleCollider2D colid;
	
	SpriteRenderer sp;
	AudioSource sound01;
	
	int count;
	public Sprite spr;

	GameObject scoreGUI;
	

	void Start(){
		brothervoice = GameObject.Find("BrotherVoice");//.GetComponent<SpriteRenderer>();

		sp = GetComponent<SpriteRenderer> ();
		colid = GetComponent<CircleCollider2D> ();
		sound01 = brothervoice.GetComponent<AudioSource> ();
		
		yamauchi = GameObject.Find ("Yamauchi");
		count = 0;
		destroytime = 3f;
		scoreGUI = GameObject.Find ("ScoreGUI");
		
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
				transform.localScale = new Vector2 (transform.localScale.x + (t2 / 15), 
				                                    transform.localScale.y + (t2 / 15));
			}
			if (t2 >= 2f && count == 0) {
				count += 1;
				if (count == 1) {
					sp.sprite = spr;
					sp.sortingOrder = 2;
					transform.localScale = new Vector2 (5, 5);
					sound01.Play ();
					}
				}
			}
		if(t2 >= 6f){
				Destroy(gameObject);
			}
		}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
			isAwake = true;
			scoreGUI.SendMessage ("AddScore", 1000000);
			colid.enabled = false;
		}
	}
}

