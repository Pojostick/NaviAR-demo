using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// http://answers.unity3d.com/questions/773464/webcamtexture-correct-resolution-and-ratio.html#answer-1148424
public class RawImageCameraTexture : MonoBehaviour {

	private WebCamTexture cameraTexture = null;
	private RawImage rawImage = null;
	public AspectRatioFitter imageFitter;

	// Image rotation
	Vector3 rotationVector = new Vector3(0f, 0f, 0f);

	// Image uvRect
	Rect defaultRect = new Rect(0f, 0f, 1f, 1f);
	Rect fixedRect = new Rect(0f, 1f, 1f, -1f);

	// Use this for initialization
	void Start () {
		cameraTexture = new WebCamTexture ();
		rawImage = GetComponent<RawImage> ();
		cameraTexture.filterMode = FilterMode.Trilinear;
		rawImage.texture = cameraTexture;
		cameraTexture.Play ();
		// reorient ();
	}
	
	// Update is called once per frame
	void Update () {
		// Skip making adjustment for incorrect camera data
		if (cameraTexture.width < 100)
		{
			Debug.Log("Still waiting another frame for correct info...");
			return;
		}

		// Rotate image to show correct orientation 
		rotationVector.z = -cameraTexture.videoRotationAngle;
		rawImage.rectTransform.localEulerAngles = rotationVector;

		// Set AspectRatioFitter's ratio
		float videoRatio = (float) cameraTexture.width / (float)  cameraTexture.height;
		imageFitter.aspectRatio = videoRatio;

		// Unflip if vertically flipped
		rawImage.uvRect = cameraTexture.videoVerticallyMirrored ? fixedRect : defaultRect;
	}
}
