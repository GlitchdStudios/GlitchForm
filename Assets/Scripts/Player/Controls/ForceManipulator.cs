using UnityEngine;
using System.Collections;

public class ForceManipulator : MonoBehaviour
{
	private Vector3 origin;
	private Vector3 direction;
	private CharacterControls characterControlsScr;
	private MouseLook mouseLookScr;
	private RaycastHit rayHit;
	private float curForce;
	public Vector3 gravity;
	public int energy;

	void Start()
	{
		characterControlsScr = transform.parent.parent.GetComponent<CharacterControls>();
		//mouseLookScr = transform.parent.parent.GetComponent<CharacterControls>();
	}

	// Update is called once per frame
	void Update ()
	{
		origin = transform.position;
		direction = transform.forward;
		if(Input.GetMouseButtonDown(0) && Physics.Raycast(origin, direction, out rayHit, 10f))
		{
			Debug.Log("Got here");
			gravity = -rayHit.normal * 9;
		}
	}
}

