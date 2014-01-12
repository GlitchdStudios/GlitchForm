using UnityEngine;
using System.Collections;

public class ChainActive : AbstractState
{
	public Collider2D otherCollider;
	public Transform trigger;
	
	public void SetupChain(Collider2D m_otherCollider, Transform m_trigger)
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

