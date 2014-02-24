using UnityEngine;
using System.Collections;

public class OrthographicCamera : MonoBehaviour 
{
	// Use this for initialization
	void Awake () 
	{
		camera.orthographicSize = ((Screen.height / 2.0f)/ 100f); // 100f is the PixelPerUnit that you have set on your sprite. Default is 100.
	}
}
