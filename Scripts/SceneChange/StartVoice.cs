using UnityEngine;
using System.Collections;

public class StartVoice : MonoBehaviour {

	AudioSource sound01;
	public float t;
	int count;

	// Use this for initialization
	void Start () {
		sound01 = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		t += Time.deltaTime;
		if (t >= 1f && count == 0) {
			count += 1;
			if (count == 1) {
				Debug.Log ("oi-");
				sound01.Play ();
			}
		}
			if(t >= 5f){
				Destroy(this);
			}
	}
  }
