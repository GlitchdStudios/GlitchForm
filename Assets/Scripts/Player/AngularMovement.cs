using UnityEngine;
using System.Collections;

public class AngularMovement : MonoBehaviour
{
	public Vector3 touchPos;
	public Transform thisTransform;
	public float speed;

	// Use this for initialization
	void Start ()
	{
		thisTransform = transform;
		speed = 2.0f * Time.deltaTime;
	}

	public void PointAtCursor()
	{
		if(Input.touchCount > 0)
		{
			touchPos = Input.GetTouch(0).position;
			touchPos = Camera.main.ScreenToWorldPoint(touchPos);
			Vector3 targetDir = touchPos - thisTransform.position;
			float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg;
			thisTransform.rotation = Quaternion.Euler(0f, 0f, angle - 90);

//			Debug.Log(touchPos);
//			Debug.Log(thisTransform.rotation);
			Debug.Log(angle);
		}
	}
}

