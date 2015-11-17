using UnityEngine;
using System.Collections;

/*
 * プレイヤーが乗る
 * プレイヤーが乗ってる間、車と同じ距離ｘ方向へ進む
 */
public class ChildScript : MonoBehaviour {
	
	private GameObject _parent;
	
	void Start(){
		
		//親オブジェクトを取得
		_parent = transform.root.gameObject;
		
		Debug.Log ("Parent:" + _parent.name);
		
	}
}
