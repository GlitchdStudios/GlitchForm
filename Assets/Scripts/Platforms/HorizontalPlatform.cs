using UnityEngine;
using System.Collections;

public class HorizontalPlatform : Platform
{
	public enum PlatformMovement {NO_MOVEMENT = -1, LEFT = 0, RIGHT }

	public PlatformMovement platformDirection;
	public float speed;

	// Use this for initialization
	void Start ()
	{
		thisTransform = transform;
		platformSwitch = GetComponentsInChildren<Switch>();
		node = thisTransform.parent.GetComponentsInChildren<Node>();
		for(int i=0; i < node.Length; i++)
		{
			node[i].renderer.enabled = false;
		}
		platformDirection = PlatformMovement.NO_MOVEMENT;
		initPlatformPos = thisTransform.position;
	}

	void Update()
	{
		MovePlatform();
	}

	public override void InitPlatform()
	{
		platformDirection = PlatformMovement.NO_MOVEMENT;
		thisTransform.position = initPlatformPos;
		for(int i = 0; i < platformSwitch.Length; i++)
		{
			if(platformSwitch[i].IsActive)
			{
				platformSwitch[i].ToggleState();
			}
		}
	}

	public void MovePlatform()
	{
		if(platformDirection != PlatformMovement.NO_MOVEMENT)
		{
			node[(int)platformDirection].MoveToNode(thisTransform, node[(int)platformDirection].transform, speed * Time.deltaTime);
		}
	}

	public override void SetDirection(Switch _switch) 
	{
		switch(_switch.name)
		{
			case "SwitchLeft":
				platformDirection = PlatformMovement.LEFT;
			                                    
			break;

			case "SwitchRight":
				platformDirection = PlatformMovement.RIGHT;  
			Debug.Log(platformDirection);
			break;
		}
	}
	public override bool HasNeutralGravity { get { return hasNeutralGravity; } }


}

