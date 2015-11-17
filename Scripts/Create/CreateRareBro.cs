using UnityEngine;
using System.Collections;

public class CreateRareBro : MonoBehaviour {

	public GameObject spawnObject;
	public float interval = 1f;
	Vector2 createPoint;

	// Use this for initialization
	void Start () {
		createPoint = new Vector2 (100, -40);
		StartSpawn ();
	}
	
	// Update is called once per frame
	void Update () {
		//interval = Random.Range (50f,100f);
		interval = Random.Range (50f,100f);
		createPoint = new Vector2 (0, 720);
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
