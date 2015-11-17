using UnityEngine;
using System.Collections;

public class Heart : MonoBehaviour {

	GameObject yamauchi;
	float xtransform;
	float ytransform;

	Rigidbody2D rigidbody2D;
	public float imp;
	public float spd;
	public float t;

	private AudioSource sound01;
	GameObject scoreGUI;

	GameObject heartSound;
	GameObject sphere;
	Sakie sakie;

	float scale;

	GameObject heart;
	CreateHeart createHeart;

	// Use this for initialization
	void Start () {
		rigidbody2D = GetComponent<Rigidbody2D> ();
		yamauchi = GameObject.Find ("Yamauchi");
		rigidbody2D.AddForce(Vector2.up * imp, ForceMode2D.Impulse);
		scoreGUI = GameObject.Find ("ScoreGUI");
		heartSound = GameObject.Find ("HeartSound");
		sound01 = heartSound.GetComponent<AudioSource> ();
		sphere = GameObject.Find("Sphere");
		sakie = sphere.GetComponent<Sakie> ();
		heart = GameObject.Find("HeartManager");
		createHeart = heart.GetComponent<CreateHeart> ();
	}
	
	// Update is called once per frame
	void Update () {

		//scale = Random.Range(0f, 3f);

		//transform.localScale = new Vector2 (scale, scale);

		xtransform = yamauchi.transform.position.x;
		ytransform = yamauchi.transform.position.y;
		t += Time.deltaTime;

		if (t >= 1) {
			transform.position = Vector2.MoveTowards (transform.position, new Vector2 (xtransform, ytransform), spd * t);
		}
		if(sakie.isCreateHeart == false){
		    createHeart.createPoint = new Vector2 (100, 760);
			Destroy(gameObject);
		}
	}
	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
			sound01.Play ();
			scoreGUI.SendMessage("AddScore", 10000);
			Destroy(gameObject);
		}
	}
}
