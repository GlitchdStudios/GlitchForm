using UnityEngine;
using System.Collections;

public class RayCastHandler : MonoBehaviour
{
	private RaycastHit rayHit;
	private Rigidbody hitObject;
	private Vector3 direction;
	private Vector3 curDirection;
	private Switch switchScr;
	private float startSpeed;
	private float curDistance;
	private float minDistance;

	public float leftRayDistance;
	public float rightRayDistance;
	public LayerMask leftMask;
	public LayerMask rightMask;
	public LayerMask pickupMask;
	public float speed;

	void Start()
	{
		startSpeed = speed;
		minDistance = 3f;
	}

	public void Interact(Vector3 origin, Vector3 direction)
	{
		if(Input.GetMouseButtonDown(0) && Physics.Raycast(origin, direction, out rayHit, leftRayDistance, leftMask))
		{
			HitSwitch();
		}
		
		if(Input.GetKeyDown(KeyCode.Space))
		{
			Toolbox.characterControls.Gravity = Vector3.down * Toolbox.generalGravityForce;
		}

		if(Toolbox.isControlable)
		{
			if(Input.GetKeyDown(KeyCode.E) && Physics.Raycast(origin, direction, out rayHit, leftRayDistance, pickupMask))
			{
				PickupObject();
			}
		}

		else
		{
			UpdateObject();
			DropObject(origin, direction);
		}
	}

	public void HitSwitch()
	{
		if(rayHit.collider.tag == "Switch")
		{
			switchScr = rayHit.collider.GetComponent<Switch>();

			if(!switchScr.IsActive)
			{
				switchScr.transform.parent.GetComponent<Platform>().SetDirection(switchScr);
			}
		}
	}

	public void ChangeGravity(Vector3 origin, Vector3 direction)
	{
		if(Input.GetMouseButtonDown(1) && Physics.Raycast(origin, direction, out rayHit, rightRayDistance, rightMask))
		{
			Toolbox.characterControls.Gravity = -rayHit.normal * Toolbox.generalGravityForce;
		}
	}

	public void PickupObject()
	{
		if(rayHit.collider.tag == "DataSphere")
		{
			hitObject = rayHit.collider.rigidbody;
			hitObject.position = Toolbox.followTrans.position;
			hitObject.constraints = RigidbodyConstraints.FreezeRotation;

			if(Toolbox.chromaState == ChromaState.BLUE)
			{
				hitObject.transform.parent = Toolbox.chroma[(int)ChromaState.BLUE].transform.parent;
			}

			if(Toolbox.chromaState == ChromaState.RED)
			{
				hitObject.transform.parent = Toolbox.chroma[(int)ChromaState.RED].transform.parent;
			}

			Toolbox.isControlable = false;
		}
	}

	public void UpdateObject()
	{
		curDistance = GetSqrDistXZ(hitObject.position, Toolbox.followTrans.position);
		curDistance = Mathf.Clamp (curDistance, 0, minDistance);
		//Debug.Log("CurDistance " + curDistance);
		speed = startSpeed * curDistance;

	 	direction = (Toolbox.followTrans.position - hitObject.position).normalized;
		hitObject.velocity = direction * speed;
	}

	public void DropObject(Vector3 origin, Vector3 direction)
	{
		if(Input.GetKeyDown(KeyCode.E) && Physics.Raycast(origin, direction, out rayHit, leftRayDistance, pickupMask))
		{
			Toolbox.isControlable = true;
			hitObject.constraints = RigidbodyConstraints.None;
		}
	}

	public float GetSqrDistXZ(Vector3 a, Vector3 b)
	{
		Vector3 vector = a - b;
		return vector.sqrMagnitude;
	}

}

