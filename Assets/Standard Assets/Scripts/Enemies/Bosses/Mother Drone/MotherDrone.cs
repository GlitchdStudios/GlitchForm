using UnityEngine;
using System.Collections;

public class MotherDrone : BaseEntity
{
	private DroneIndicator droneIndRef;
	// Use this for initialization
	void Start ()
	{
		droneIndRef = GetComponentInChildren<DroneIndicator>();
	}

	// Update is called once per frame
	void Update ()
	{
		droneIndRef.ChangeAniFrame();
	}
}

