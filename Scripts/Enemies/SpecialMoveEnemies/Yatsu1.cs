using UnityEngine;
using System.Collections;

public class Yatsu1 : MonoBehaviour {
	
	public float dropPoint = -50f;
	float t;

	void FixedUpdate(){

		t += Time.deltaTime;

		transform.position = new Vector2 (transform.position.x - (t * Random.Range (-0.5f, 0.5f)), transform.position.y);

		if (t >= 3) {
			Destroy (gameObject);
		}

		if (transform.position.y <= dropPoint) {
			Destroy (gameObject);
		}

		//if (isRotate == true) {
			//t = 120 * Time.deltaTime;
			//transform.localScale = new Vector2(transform.localScale.x * t ,transform.localScale.y * t);

		//}
	}
	

	void OnTriggerEnter2D(Collider2D col){
	if (col.gameObject.tag == "Player") {
			Destroy(this);
		}
    }
}
