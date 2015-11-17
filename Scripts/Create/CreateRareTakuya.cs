using UnityEngine;
using System.Collections;

public class CreateRareTakuya : MonoBehaviour {

	public GameObject spawnObject;
	public float interval = 30f;
	Vector2 createPoint;

	// Use this for initialization
	void Start () {
		createPoint = new Vector2 (100, -40);
		StartSpawn ();
	}
	
	// Update is called once per frame
	void Update () {
		interval = Random.Range (50f, 60f);
		createPoint = new Vector2 (Random.Range (-30f, 30f), Random.Range (10f, 13f));
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
