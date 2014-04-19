using UnityEngine;
using System.Collections;

public class CorruptTrap : Trap
{

	// Use this for initialization
	void Start ()
	{
	
	}

    public override void AffectPlayer() {}
	public override bool ToggleState() { isActive = true ? false : true;  return isActive; }
	public override void CheckState(bool _isActive) {}
	public override bool IsActive { get { return isActive; } }
}

