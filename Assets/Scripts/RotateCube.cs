using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCube : MonoBehaviour {

	private Vector3 rotateVector = new Vector3(10.0F, 20.0F, 40.0F);

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Transform> ().Rotate(rotateVector * Time.deltaTime);
	}
}
