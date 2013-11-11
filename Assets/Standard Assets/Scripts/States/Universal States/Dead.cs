using UnityEngine;
using System.Collections;

public class Dead : AbstractState
{
	private GameObject deadObj;
	
	public override void ResolveState()
	{
		Destroy(DeadGameObject);
	}
	
	public GameObject DeadGameObject {get {return deadObj;} set{deadObj = value;} }
}

