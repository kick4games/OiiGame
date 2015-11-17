using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {

	private AudioSource sound01;
	GameObject scoreGUI;

	void Start(){
		scoreGUI = GameObject.Find ("ScoreGUI");
	}

	void OnTriggerEnter2D(Collider2D col){
	if (col.gameObject.tag == "Player") {
			Destroy(gameObject);
		}
	if (col.gameObject.tag == "Player") {
			scoreGUI.SendMessage("AddScore", 1);
		}
	}
}

