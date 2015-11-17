using UnityEngine;
using System.Collections;

public class Keisuke : MonoBehaviour {

	private AudioSource sound01;
	GameObject scoreGUI;
	Rigidbody2D rigidbody2D;
	public float gra = 10f;
	public float ang = 10f;
	float t;
	public float dropPoint = -50f;
	bool isRotate;

	void Start(){
		scoreGUI = GameObject.Find ("ScoreGUI");
		sound01 = GetComponent<AudioSource> ();
		rigidbody2D = GetComponent<Rigidbody2D>();
		t = 1;

	}

	void FixedUpdate(){
		if (transform.position.y <= dropPoint) {
			Destroy (gameObject);
		}
		if (isRotate == true) {
			t = 1 * Time.deltaTime;
			transform.Rotate(0, 0, t * 2000);
		}
	}
	

	void OnTriggerEnter2D(Collider2D col){
	if (col.gameObject.tag == "Player") {

			sound01.Play();
			//rigidbody2D.AddForce(Vector2.up * imp, ForceMode2D.Impulse);
			//rigidbody2D.AddForce(-Vector2.right * imp, ForceMode2D.Impulse);

			float angle = 40;
			//Rigidbody2D m_rigidbody = GetCompoment<Rigidbody2D>();
			//float distance = Vector2.Distance (transform.position, target.transform.position);
			float gravity = Mathf.Abs(Physics.gravity.y) * rigidbody2D.gravityScale;
			float direction = angle * Mathf.Deg2Rad;
			float sin = Mathf.Sin (direction);
			float cos = Mathf.Cos (direction);
			float speed = Mathf.Sqrt ((gravity * gra) / (15.0f * sin * cos)) * ang; // forceは係数
			rigidbody2D.AddForce (new Vector2(Mathf.Cos(direction) * speed, Mathf.Sin(direction) * speed));

		}

	if (col.gameObject.tag == "Player") {
			scoreGUI.SendMessage("AddScore", 1);
		}

	if (col.gameObject.tag == "Player") {
			isRotate = true;
		}
	}
}

