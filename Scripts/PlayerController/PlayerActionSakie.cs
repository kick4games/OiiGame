using UnityEngine;
using System.Collections;

public class PlayerActionSakie : MonoBehaviour {

	//Vector2 toGoPoint = new Vector2(0, 762);
	public float spd = 0.0005f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//transform.LookAt (toGoPoint);
		transform.position = Vector2.MoveTowards (transform.position, new Vector2 (0, 762),spd);
		//transform.position += transform.up * spd * Time.deltaTime;
	}
}
