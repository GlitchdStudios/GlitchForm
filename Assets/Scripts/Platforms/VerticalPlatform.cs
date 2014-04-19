using UnityEngine;
using System.Collections;

public class VerticalPlatform : Platform
{
	public enum PlatformMovement {NO_MOVEMENT = -1, DOWN = 0, UP }

	public PlatformMovement platformDirection;

	// Use this for initialization
	void Start ()
	{
		thisTransform = transform;
		platformSwitch = GetComponentsInChildren<Switch>();
		node = thisTransform.parent.GetComponentsInChildren<Node>();
		initPlatformPos = thisTransform.position;
	}

	public override void InitPlatform()
	{
		platformDirection = PlatformMovement.NO_MOVEMENT;
		thisTransform.position = initPlatformPos;
	}

	public override void SetDirection(Switch _switch) 
	{
		switch(_switch.name)
		{
		case "SwitchUp":
			animation.Play("Up");
			_switch.ToggleState();
			
			if(platformSwitch[(int)PlatformMovement.DOWN].IsActive)
			{
				platformSwitch[(int)PlatformMovement.DOWN].ToggleState();
			}
			
			break;
			
		case "SwitchDown":
			animation.Play("Down");
			_switch.ToggleState();
			
			if(platformSwitch[(int)PlatformMovement.UP].IsActive)
			{
				platformSwitch[(int)PlatformMovement.UP].ToggleState();
			}
			break;
		}
	}
	public override bool HasNeutralGravity { get { return hasNeutralGravity; } }
	
	
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
}

