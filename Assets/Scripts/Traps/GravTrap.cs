using UnityEngine;
using System.Collections;

public class GravTrap : Trap
{
	void Start()
	{
		Invoke("ToggleState", 2);
	}

	public override void AffectPlayer() 
	{ 
		if(isActive)
		{
			Toolbox.characterControls.Gravity = this.transform.up * Toolbox.generalGravityForce; 
		}
	}
	public override bool ToggleState() 
	{ 
		isActive = (isActive == true) ? false : true;
		//Debug.Log(isActive);
		Invoke("ToggleState", 2);
		return isActive; 
	}
	public override void CheckState(bool _isActive) {}

	void OnTriggerStay(Collider col)
	{
		if(col.tag == "Player")
			AffectPlayer();
	}

	public override bool IsActive { get { return isActive; } }
}

