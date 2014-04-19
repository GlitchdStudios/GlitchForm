using UnityEngine;
using System.Collections;

public class YRotationalPlatform : Platform
{
	enum PlatformMovement { ROTATE_UP = 0, ROTATE_DOWN }
	// Use this for initialization
	void Start ()
	{
		thisTransform = transform;
		platformSwitch = GetComponentsInChildren<Switch>();
	}

	public override void InitPlatform() {}

	public override void SetDirection(Switch _switch) 
	{ 
		switch(_switch.name)
		{
			case "SwitchRotUp":
				animation.Play("RotateUp");
				_switch.ToggleState();
				
				if(platformSwitch[(int)PlatformMovement.ROTATE_DOWN].IsActive)
				{
					platformSwitch[(int)PlatformMovement.ROTATE_DOWN].ToggleState();
				}
				
				break;
				
			case "SwitchRotDown":
				animation.Play("RotateDown");
				_switch.ToggleState();
				
				if(platformSwitch[(int)PlatformMovement.ROTATE_UP].IsActive)
				{
					platformSwitch[(int)PlatformMovement.ROTATE_UP].ToggleState();
				}
				break;
		}

	}

	void OnTriggerEnter(Collider col)
	{
		if(col.tag == "Player")
		{
			col.transform.parent = thisTransform;
		}
	}
	
	void OnTriggerExit(Collider col)
	{
		if(col.tag == "Player")
		{
			col.transform.parent = null;
		}
	}

	public override bool HasNeutralGravity { get { return hasNeutralGravity; } }
}

