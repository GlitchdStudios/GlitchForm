using UnityEngine;
using System.Collections;

public abstract class Platform : MonoBehaviour
{
	protected Transform thisTransform;
	protected bool hasNeutralGravity;  //Flag used to designate platforms that the play cannot use raycasts on

	protected Switch[] platformSwitch;

	abstract public void MovePlatform(Switch _switch); 
	abstract public bool HasNeutralGravity { get;}
}

