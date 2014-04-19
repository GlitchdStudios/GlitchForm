using UnityEngine;
using System.Collections;

public enum DataState { EMPTY = 0, CORRUPTED_DATA, BACKDOOR_DATA, AREAPORTAL_DATA }

public class DataSphere : Utility
{
	private DataState dataState;

	public DataState thisDataState;
	public Vector3 initPos;

	// Use this for initialization
	void Start ()
	{
		dataState = thisDataState;
		initPos = this.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public override bool ToggleState() { isActive = (isActive == true) ? false : true; return isActive; }
	public override void CheckState(bool _isActive) {}

	//Accessors
	public override bool IsActive { get { return isActive;} } 
	public DataState GetDataState { get { return dataState; } }
}

