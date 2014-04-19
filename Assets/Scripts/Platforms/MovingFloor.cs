using UnityEngine;
using System.Collections;

public class MovingFloor : MonoBehaviour
{
	public enum PlatformMovement { FORWARD = 0, BACKWARD }

	protected bool hasNeutralGravity;
	private Transform thisTransform;

	public PlatformMovement platformMovement;
	public float force;

	// Use this for initialization
	void Start ()
	{
		thisTransform = transform;
	}

	public void MovePlayer(Collider col)
	{
		if(col.tag == "Player")
		{
			switch(platformMovement)
			{	
				case PlatformMovement.FORWARD:
					col.rigidbody.AddForce(thisTransform.forward * force);
				break;

				case PlatformMovement.BACKWARD:
					col.rigidbody.AddForce(thisTransform.TransformDirection(Vector3.back) * force);
				break;
			}
		}
	}


	void OnTriggerStay(Collider col)
	{
		MovePlayer(col);
		Debug.Log("HERE!");
	}

	public bool HasNeutralGravity { get { return hasNeutralGravity; } }
}

