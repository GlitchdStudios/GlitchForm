using UnityEngine;
using System.Collections;

public class Cloud : MonoBehaviour
{
	Rigidbody2D thisRigidbody;
	Transform thisTransform;

	// Use this for initialization
	void Start ()
	{
		thisRigidbody = rigidbody2D;
		thisTransform = transform;
		rigidbody2D.AddForce(thisTransform.right * 20f);
	}
}

