using UnityEngine;
using System.Collections;

public class CreateAirMiddle: MonoBehaviour {

	public GameObject spawnObject;
	public float interval = 5f;
	Vector2 createPoint;

	// Use this for initialization
	void Start () {
		createPoint = new Vector2 (100, -40);
		
		StartSpawn ();
	}
	
	// Update is called once per frame
	void Update () {
		createPoint = new Vector2 (Random.Range (-15f, 15f),Random.Range(580f,640f));
	}
	IEnumerator SpawnCoins(){
		while (true) {
			Instantiate(spawnObject,createPoint, transform.rotation);
			yield return new WaitForSeconds(interval);
		}
	}
	public void StartSpawn(){
		StartCoroutine ("SpawnCoins");
	}
	public void StopSpawn(){
		StopCoroutine ("SpawnCoins");
	}
}
