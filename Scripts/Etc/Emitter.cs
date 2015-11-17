using UnityEngine;
using System.Collections;

public class Emitter : MonoBehaviour {
	
	public GameObject spawnObject;
	Vector2 createPoint;

	void Start(){
		StartSpawn ();
	}
	void Update(){
		createPoint = new Vector2 (30f, 0f);
	}

	IEnumerator SpawnBGs(){
		while (true) {
			Instantiate(spawnObject,createPoint, transform.rotation);
			yield return new WaitForSeconds(10f);
		}
	}
	public void StartSpawn(){
		StartCoroutine ("SpawnBGs");
	}
	public void StopSpawn(){
		StopCoroutine ("SpawnBGs");
	}
}