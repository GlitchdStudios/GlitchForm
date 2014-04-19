using UnityEngine;
using System.Collections;

public class DataManipulator : MonoBehaviour
{
	private Vector3 origin;
	private Vector3 direction;
	private RayCastHandler rayHandler;
	public int energy;

	void Start()
	{
		rayHandler = GetComponent<RayCastHandler>();
	}

	// Update is called once per frame
	void Update ()
	{
		origin = transform.position;
		direction = transform.forward;

		rayHandler.Interact(origin, direction);
		rayHandler.ChangeGravity(origin, direction);
	}
}

