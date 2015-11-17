using UnityEngine;
using System.Collections;

public class Sakie : MonoBehaviour {

	bool isAwake;
	public bool isCreateHeart;
	float t;
	float t2;
	GameObject sakieFace2;
	GameObject sakieFace3;
	GameObject yamauchi;
	GameObject sakievoice1;
	GameObject sakievoice2;
	GameObject sakievoice3;
	
	SpriteRenderer sp2;
	SpriteRenderer sp3;
	AudioSource sound01;
	AudioSource sound02;
	AudioSource sound03;
	CircleCollider2D polygon;

	int count;
	Transform ytransform;
	int r;

	void Start(){
		sakieFace2 = GameObject.Find("SakieFace2");//.GetComponent<SpriteRenderer>();
		sakieFace3 = GameObject.Find ("SakieFace3-1");//.GetComponent<SpriteRenderer>();
		sakievoice1 = GameObject.Find("SakieVoice1");//.GetComponent<SpriteRenderer>();
		sakievoice2 = GameObject.Find("SakieVoice2");//.GetComponent<SpriteRenderer>();
		sakievoice3 = GameObject.Find("SakieVoice3");//.GetComponent<SpriteRenderer>();
		
		sp2 = sakieFace2.GetComponent<SpriteRenderer> ();
		sp3 = sakieFace3.GetComponent<SpriteRenderer> ();
		sound01 = sakievoice1.GetComponent<AudioSource> ();
		sound02 = sakievoice2.GetComponent<AudioSource> ();
		sound03 = sakievoice3.GetComponent<AudioSource> ();
		
		yamauchi = GameObject.Find ("Yamauchi");
		ytransform = yamauchi.GetComponent<Transform> ();
		polygon = GetComponent<CircleCollider2D> ();
	}

	// Update is called once per frame
	void Update () {
		if (gameObject.tag == "Untagged") {
			t += Time.deltaTime;
			if(ytransform.position.y <= 740f){
				gameObject.tag = "Sakie";
			}
		}
		if (isAwake) {
//			ytransform.position = yamauchi.transform.position.y;
			t2 += Time.deltaTime;
			if (t2 >= 2f) {
				sp2.sortingOrder = -2;
			}
			if(t2 >= 3f){
				sp2.sortingOrder = -4;
				sp3.sortingOrder = -1;
				count += 1;
				if(count == 1 ){
					r = Random.Range(1,4);
					if(r == 1){
						sound01.Play();
						isCreateHeart = true;
					}
					if(r == 2){
						sound02.Play();
						isCreateHeart = true;
					}
					if(r == 3){
						sound03.Play();
						isCreateHeart = true;
					}
				}
				if(ytransform.position.y >= 770f){
					isCreateHeart = false;
					polygon.enabled = false;
				}
				if(ytransform.position.y <= 740f){
					sp3.sortingOrder = -5;
					polygon.enabled = true;
					isCreateHeart = false;
					isAwake = false;
					
				}
			}
		}
		if(isAwake == false){
			t2 = 0;
			r = 0;
			count = 0;
			
		}
	}
	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
			gameObject.tag = "Untagged";
			isAwake = true;
		}
    }
}
