using UnityEngine;
using System.Collections;

public class RayCastHandler : MonoBehaviour
{
	private bool isControlable = true;
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

		if(isControlable)
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

		Debug.Log(isControlable);
	}

	public void HitSwitch()
	{
		if(rayHit.collider.tag == "Switch")
		{
			Debug.Log("IF 1");
			switchScr = rayHit.collider.GetComponent<Switch>();

			if(!switchScr.IsActive)
			{
				Debug.Log("IF 2");
				switchScr.transform.parent.GetComponent<Platform>().SetDirection(switchScr);
			}
		}
	}

	public void ChangeGravity(Vector3 origin, Vector3 direction)
	{
		if(Input.GetMouseButtonDown(1) && Physics.Raycast(origin, direction, out rayHit, rightRayDistance, rightMask))
		{
			Toolbox.characterControls.Gravity = -rayHit.normal * Toolbox.generalGravityForce;
			Debug.Log(Toolbox.characterControls.Gravity);
		}
	}

	public void PickupObject()
	{
		if(rayHit.collider.tag == "DataSphere")
		{
			Debug.Log("hit DataSphere");
			hitObject = rayHit.collider.rigidbody;
			//Debug.Log(Vector3.Distance(hitObject.position, this.transform.position));
			hitObject.position = Toolbox.followTrans.position;
			hitObject.constraints = RigidbodyConstraints.FreezeRotation;
			isControlable = false;
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
			isControlable = true;
			hitObject.constraints = RigidbodyConstraints.None;
		}
	}

	public float GetSqrDistXZ(Vector3 a, Vector3 b)
	{
		Vector3 vector = a - b;
		return vector.sqrMagnitude;
	}

}

