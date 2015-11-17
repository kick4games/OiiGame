using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class SceneChangeGameOver : MonoBehaviour {

	float t ;
	private AudioSource sound01;
	bool isTime;

	void Start(){
		sound01 = GetComponent<AudioSource> ();
	}

	void Update(){
		if (isTime) {
			t += Time.deltaTime;
		}
	}
	
	void FixedUpdate () {
		if (CrossPlatformInputManager.GetButtonDown ("Jump")) {
			sound01.Play ();
			isTime = true;
		}
		if(t >= 0.5f){
			isTime = false;
			Application.LoadLevel("Stage1");
		}
	}
}
