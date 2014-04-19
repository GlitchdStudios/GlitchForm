using UnityEngine;
using System.Collections;

public class Switch : Utility
{
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public override bool ToggleState() { isActive = (isActive == true) ? false : true;  return isActive; }
	public override void CheckState(bool _isActive) { Debug.Log(_isActive); }
	public override bool IsActive { get { return isActive; } }
}

