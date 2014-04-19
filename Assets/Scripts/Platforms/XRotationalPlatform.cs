using UnityEngine;
using System.Collections;

public class XRotationalPlatform : Platform
{
	public enum PlatformMovement {NO_ROTATION = -1, ROTATE_LEFT = 0, ROTATE_RIGHT}

	public PlatformMovement platformDirection;
	public Quaternion initPlatfromRotation;
	public float speed;

	// Use this for initialization
	void Start ()
	{
		thisTransform = transform;
		platformSwitch = GetComponentsInChildren<Switch>();
		node = thisTransform.root.GetComponentsInChildren<Node>();
		for(int i=0; i < node.Length; i++)
		{
			node[i].renderer.enabled = false;
		}
		initPlatfromRotation = thisTransform.parent.rotation;
	}

	void Update()
	{
		MovePlatform();
	}

	public override void InitPlatform()
	{
		platformDirection = PlatformMovement.NO_ROTATION;
		thisTransform.parent.rotation = initPlatfromRotation;
	}

	public void MovePlatform()
	{
		if(platformDirection != PlatformMovement.NO_ROTATION)
		{
			node[(int)platformDirection].RotateToNode(thisTransform.parent, node[(int)platformDirection].transform, speed);
		}
	}

	public override void SetDirection(Switch _switch) 
	{
		switch(_switch.name)
		{
		case "SwitchRotLeft":
			platformDirection = PlatformMovement.ROTATE_LEFT;
			
			break;
			
		case "SwitchRotRight":
			platformDirection = PlatformMovement.ROTATE_RIGHT;  
			Debug.Log(platformDirection);
			break;
		}
	}

	public override bool HasNeutralGravity { get { return hasNeutralGravity; } }
}

