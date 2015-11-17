using UnityEngine;
using System.Collections;

public class TestMove : MonoBehaviour {

	float t;
	Rigidbody2D rigidbody2D ;

	// Use this for initialization
	void Start () {
		t = 0;
		rigidbody2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
	
		t += Time.deltaTime ;

		if (t >= 5f) {
			rigidbody2D.velocity = new Vector2 (1000, rigidbody2D.velocity.y);
			
		}

	}
}
