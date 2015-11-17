using UnityEngine;
using System.Collections;

public class ParentScript : MonoBehaviour {
	
	private GameObject _child;
	
	// Use this for initialization
	void Start () {
		_child = transform.FindChild ("Yamauchi").gameObject;
		Debug.Log("Child is:" + _child.name);
	}
}