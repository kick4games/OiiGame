using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class SceneChangeCredit2 : MonoBehaviour {

	float t;

	void FixedUpdate () {
		t += Time.deltaTime;
		if (t >= 3f) {
			Application.LoadLevel("Start");
		}
	}
}
