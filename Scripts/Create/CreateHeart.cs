using UnityEngine;
using System.Collections;

public class CreateHeart: MonoBehaviour {
	
	public GameObject spawnObject;
	public float interval = 0.1f;
	public Vector2 createPoint;
	GameObject sphere;
	GameObject yamauchi;
	PlayerController plc;
	Sakie sakie;
	
	// Use this for initialization
	void Start () {
		createPoint = new Vector2 (100, 760);
		StartSpawn ();
		yamauchi = GameObject.Find("Yamauchi");
		plc = yamauchi.GetComponent<PlayerController> ();
		sphere = GameObject.Find("Sphere");
		sakie = sphere.GetComponent<Sakie> ();
	}
	
	// Update is called once per frame
	void Update () {

		if(sakie.isCreateHeart){
		    createPoint = new Vector2 (Random.Range (Random.Range(-19f,-2f), Random.Range(2f,18f)),Random.Range(759f,783f));
		//	if(plc.heartCount >= 100){
		//		StopSpawn();
		//		plc.heartCount = 0;
		//		sakie.isCreateHeart = false;
		//		Debug.Log("ha-toend");
			//}
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