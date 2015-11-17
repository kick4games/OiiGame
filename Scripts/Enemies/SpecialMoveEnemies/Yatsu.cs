using UnityEngine;
using System.Collections;

public class Yatsu : MonoBehaviour {

	private AudioSource sound01;
	GameObject scoreGUI;
	Rigidbody2D rigidbody2D;
	//public float gra = 10f;
	//public float ang = 10f;
	public float t;
	public float dropPoint = -50f;
	bool isTouch;

	public GameObject camera;
	Transform cTransform;
	public GameObject hero;
	Transform hTransform;

	PlayerController pc;

	int camAdjust;

	//pas = yamauchi.GetComponent<PlayerActionSakie>();

	void Start(){
		scoreGUI = GameObject.Find ("ScoreGUI");
		sound01 = GetComponent<AudioSource> ();
		rigidbody2D = GetComponent<Rigidbody2D>();

		camera = GameObject.Find ("Main Camera");
		cTransform = camera.transform;

		hero = GameObject.Find ("Yamauchi");
		hTransform = hero.transform;

		pc = hero.GetComponent<PlayerController> ();
		camAdjust = 0;
	}

	void FixedUpdate(){

		if (isTouch == true && pc.isSakie == false && pc.isNorihiko == false && pc.isBro == false) {

			gameObject.tag = "Untagged";
			t += Time.deltaTime;

			cTransform.position = new Vector2 (0, hTransform.position.y - 1.5f);
			transform.position = new Vector2 (transform.position.x - (0.3f * t), hTransform.position.y - 1);
						
			if (pc.isCameraReset) {
				camAdjust += 1;
				if (camAdjust == 1) {
					t -= 1;
				}
			}

				if (t >= 6.5f && pc.isSakie == false) {
					cTransform.position = new Vector2 (0, 7);
					Destroy (gameObject);
				}
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

			sound01.Play();
			//rigidbody2D.AddForce(Vector2.up * imp, ForceMode2D.Impulse);
			//rigidbody2D.AddForce(-Vector2.right * imp, ForceMode2D.Impulse);

			//float angle = 40;
			//Rigidbody2D m_rigidbody = GetCompoment<Rigidbody2D>();
			//float distance//ctor2.Distance (transform.position, target.transform.position);
			//float gravity = Mathf.Abs(Physics.gravity.y) * rigidbody2D.gravityScale;
			//float direction = angle * Mathf.Deg2Rad;
			//float sin = Mathf.Sin (direction);
			//float cos = Mathf.Cos (direction);
			//float speed = Mathf.Sqrt ((gravity * gra) / (15.0f * sin * cos)) * ang; // forceは係数
			//rigidbody2D.AddForce (new Vector2(Mathf.Cos(direction) * speed, Mathf.Sin(direction) * speed));

		}

	if (col.gameObject.tag == "Player") {
			scoreGUI.SendMessage("AddScore", 1);
		}

	if (col.gameObject.tag == "Player") {
			isTouch = true;
		}
	}
}

