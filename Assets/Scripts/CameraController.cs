using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraController : MonoBehaviour {

	public Light flashlight;

	private float speed = 100.0F;

	// Use this for initialization
	void Start () {
		Input.gyro.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		Quaternion rotation = getDeviceOrientation ();

		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began) {
			Debug.Log (rotation.ToString ());
		}

		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Stationary) {
			GetComponent<Transform> ().Translate (speed * Vector3.forward * Time.deltaTime, Camera.main.transform);
			flashlight.GetComponent<Transform> ().position = GetComponent<Transform> ().position;
		}

		GetComponent<Transform> ().rotation = rotation;
		flashlight.GetComponent<Transform> ().rotation = rotation;
	}

	Quaternion getDeviceOrientation () {
		Quaternion gyro = Input.gyro.attitude;
		Quaternion rotation = new Quaternion (gyro.x, gyro.y, -gyro.z, -gyro.w); // Unity is left handed, Gyroscope is right handed

		return rotation;
	}
}
