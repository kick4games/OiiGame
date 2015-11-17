using UnityEngine;
using System.Collections;

public class CreateStart: MonoBehaviour {

	public GameObject spawnObject;
	public float interval = 5f;
	Vector2 createPoint;
	public float p;

	// Use this for initialization
	void Start () {
		createPoint = new Vector2 (100, -40);
		
		StartSpawn ();
		p = -3;
	}
	
	// Update is called once per frame
	void Update () {

		p += Time.deltaTime;

		if (p <= 3) {
			createPoint = new Vector2 (p * 5, 0);
		} else {
			p = -3;
		}
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
