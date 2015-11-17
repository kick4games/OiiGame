using UnityEngine;
using System.Collections;

public class BGMControllerOff : MonoBehaviour {

	GameObject skybgm;
	AudioSource sound01;
	GameObject bgm1;
	AudioSource sound02;
	

	void Start () {
	
		skybgm = GameObject.Find ("SkyBGM");
		bgm1 = GameObject.Find("BGM1");
		sound01 = skybgm.GetComponent<AudioSource> ();
		sound02 = bgm1.GetComponent<AudioSource> ();
		

	}
	
	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
			sound01.mute = true;
			sound02.mute = false;
		}
	}
}