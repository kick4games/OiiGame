using UnityEngine;
using System.Collections;

public class WannaBeChild : MonoBehaviour {
	
	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "loof") {
			transform.parent = GameObject.Find ("loof").transform;
		}
	}
	void OnTriggerExit2D(Collider2D col){
		if (col.gameObject.tag == "loof") {
			transform.parent = null;
		}
	}
}