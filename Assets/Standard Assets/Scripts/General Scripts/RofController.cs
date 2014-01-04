using UnityEngine;
using System.Collections;

public class RofController : MonoBehaviour
{
	private bool locked;
	private float rofForBase;
	private float rofForAbilities;
	
	void Update()
	{
		CheckTimer();
	}

	private void SetupRoF()
	{
		if(WeaponManager.Instance.CurAbilitySet.Contains(WeaponManager.Instance.chainScr))
		{
			rofForAbilities = Time.time + WeaponManager.Instance.RoF;
		}
		else
		{
			rofForBase = Time.time + WeaponManager.Instance.RoF;
		}
	}

	private void CheckTimer()
	{
		if(WeaponManager.Instance.CurAbilitySet.Contains(WeaponManager.Instance.chainScr))
		{
			if(rofForAbilities <= Time.time)
			{
				Unlock();
			}
		}

		else
		{
			if(rofForBase <= Time.time)
			{
				Unlock();
			}
		}
	}

	public void Lock()
	{
		locked = true;

		SetupRoF();
	}
	
	public void Unlock()
	{
		locked = false;
	}
	
	public bool IsInputLocked()
	{
		return locked;
	}
}

