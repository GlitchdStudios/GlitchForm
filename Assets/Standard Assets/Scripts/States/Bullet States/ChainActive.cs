using UnityEngine;
using System.Collections;

public class ChainActive : AbstractState
{
	public Collider otherCollider;
	public Transform trigger;
	
	public void SetupChain(Collider m_otherCollider, Transform m_trigger)
	{
		otherCollider = m_otherCollider;
		trigger = m_trigger;
	}
	
	public override void ResolveState()
	{
		if(WeaponManager.Instance.CurAbilitySet.Contains(WeaponManager.Instance.chainScr))  // if chain ability
		{
			WeaponManager.Instance.chainScr.ActivateChainBullet(trigger, otherCollider);
		}
	}
}

