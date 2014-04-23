using UnityEngine;
using System.Collections;

public abstract class Platform : MonoBehaviour
{
	protected Transform thisTransform;
	protected bool hasNeutralGravity;  //Flag used to designate platforms that the play cannot use raycasts on
	protected Node[] node;

	public Vector3 initPlatformPos;
	public Switch[] platformSwitch;

	abstract public void SetDirection(Switch _switch); 
	abstract public bool HasNeutralGravity { get;}
	abstract public void InitPlatform();
}

