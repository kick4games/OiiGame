using UnityEngine;
using System.Collections;

public class CreateMoveAoyagi : MonoBehaviour {

	public GameObject spawnObject;
	public float interval = 50f;
	Vector2 createPoint;

	// Use this for initialization
	void Start () {
		createPoint = new Vector2 (-100, -40);
		StartSpawn ();
	}
	
	// Update is called once per frame
	void Update () {
		interval = Random.Range (40f, 90f);
		createPoint = new Vector2 (26, 0.8f);
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
