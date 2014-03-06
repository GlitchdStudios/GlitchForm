using UnityEngine;
using System.Collections;

public class AngularMovement : MonoBehaviour
{
	private int minAngle;
	private int maxAngle;
	private Quaternion curRotation;

	public Vector3 touchPos;
	public Transform thisTransform;
	public float speed;

	// Use this for initialization
	void Start ()
	{
		thisTransform = transform;
		maxAngle = 150;
		minAngle = 30;
	}

	public void PointAtCursor()
	{
		if(Input.touchCount > 0)
		{
			touchPos = Input.GetTouch(0).position;
			touchPos = Camera.main.ScreenToWorldPoint(touchPos);
			Vector3 targetDir = touchPos - thisTransform.position;
			float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg;
			if(angle < 0)
			{
				angle *= -1;
			}
			angle = Mathf.Clamp(angle, minAngle, maxAngle);
			curRotation = Quaternion.Euler(0f, 0f, angle-90);
			thisTransform.rotation = Quaternion.Slerp(thisTransform.rotation, curRotation, speed * Time.deltaTime);
//			Debug.Log(touchPos);
//			Debug.Log(thisTransform.rotation);
			Debug.Log(angle);
		}
	}
}

