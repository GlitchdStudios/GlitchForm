using UnityEngine;
using System.Collections;

public class SpikeTrap : Trap
{
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public override void AffectPlayer() {}
	public override bool ToggleState() { isActive = (isActive == true) ? false : true; return isActive; }
	public override void CheckState(bool _isActive) {}
	public override bool IsActive { get { return isActive; } }
}

