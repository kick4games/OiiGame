using UnityEngine;
using System.Collections;

public class Car : MonoBehaviour {

	/*
	 * 出現
	 * エンジンかける音
	 * F1音
	 * 横に動く
	 * ダメージオブジェクに当たったら、衝突音と共に相手をはじき飛ばす
	 * プレイヤーに当たったら、ブレーキ音を鳴らし
	 * プレイヤー死、
	 * 青柳のレイヤーを上げて顔を出現、
	 * 青柳ボイスを鳴らす
	 */

	float t = 0.1f;
	public float spd;
	public float destroypoint = -25f;
	int count ;
	int count2 ;
	int count3 ;
	bool isTouchedPlayer;
	bool isAwake;
	bool isMove;

	AudioSource sound01;
	AudioSource sound02;
	AudioSource sound03;
	AudioSource sound04;
	AudioSource sound05;
	SpriteRenderer spr;
	
	void Start () {
		sound01 = GameObject.Find ("CarSound1").GetComponent<AudioSource> ();
		sound02 = GameObject.Find ("CarSound2").GetComponent<AudioSource> ();
		sound03 = GameObject.Find ("CarSound3").GetComponent<AudioSource> ();
		sound04 = GameObject.Find ("AoyagiVoice").GetComponent<AudioSource> ();
		sound05 = GameObject.Find ("CollisionSound").GetComponent<AudioSource> ();
		spr = GameObject.Find ("Aoyagi1").GetComponent<SpriteRenderer> ();
		isAwake = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (isAwake && transform.position.x >= destroypoint) {
			t -= Time.deltaTime;
			if(t <= 0f){
				count += 1;
				t = 0.1f;
				if(count == 1){
					sound01.Play ();
				}
				if(count == 35){
					count = 0;
					isMove = true;
					isAwake = false;
				}
			}
		}
		if (isMove && isTouchedPlayer == false) {
			t -= Time.deltaTime;
			if(t <= 0f){
				count2 += 1;
				t = 0.1f;
				if(count2 == 1){
					sound02.Play();
				}
			}
			transform.position = new Vector2 (transform.position.x - spd, 0.8f);
		}
		if (isTouchedPlayer) {
			t -= Time.deltaTime;
			if(t <= 0f){
				count3 += 1;	
				t = 0.1f;
					if(count3 == 1){
						sound03.Play ();
						sound05.Play();
					}
				if(count3 == 6){
				spr.sortingOrder = 3;
				sound04.Play ();
				}
			}
		}
		if (  transform.position.x <= destroypoint) {
			Destroy(gameObject);
		}
	}
	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Player") {

			isTouchedPlayer = true;

					}
	}
}