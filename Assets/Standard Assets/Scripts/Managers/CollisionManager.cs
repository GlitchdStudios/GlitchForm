using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CollisionManager : Singleton<CollisionManager>
{	
	public void PlayerTriggerEnter(Collider otherCollider, Transform trigger)
	{
		if(otherCollider != null && trigger != null)
		{
			if(otherCollider.name == "DroneTrigger")
			{
				Drone droneRef = otherCollider.transform.parent.GetComponent<Drone>();
				droneRef.speed = 0;		
			}
			
			if(otherCollider.name == "Chain")
			{
				WeaponManager.Instance.bulletScr.SetAbilities(PickupManager.Instance.abilityCollection[(int)AbilityTypes.Chain]);
					
				Debug.Log("Chain!!!!!!!!"  + PickupManager.Instance.abilityCollection[(int)AbilityTypes.Chain]);
			}
		}
	}
	
	public void PlayerTriggerStay(Collider otherCollider, Transform trigger)
	{
		if(otherCollider != null)
		{
			if(otherCollider.name == "DroneTrigger")
			{
				if(otherCollider != null && trigger != null)
				{
					Drone droneRef = otherCollider.transform.parent.GetComponent<Drone>();
					Player playerRef = trigger.parent.GetComponent<Player>();
					
					StateManager.Instance.orbiting.SetOrbit(otherCollider, trigger);
					droneRef.ActivateState();
						
					if(!droneRef.damagePlayer)
						StartCoroutine(DroneAttack(playerRef, droneRef));
					
					//Debug.Log("Health: " + playerRef.health);
				}
			}
		}
	}
	
	public void PlayerTriggerExit(Collider otherCollider)
	{	
		if(otherCollider != null)
		{
			if(otherCollider.name == "DroneTrigger")
			{
				otherCollider.transform.parent.GetComponent<Drone>().speed = 5f;
			}
		}
	}
	
	public void DroneTriggerEnter(Collider otherCollider, Transform trigger)
	{
		Drone droneRef = trigger.transform.parent.GetComponent<Drone>();
		Bullet bulletRef = otherCollider.GetComponent<Bullet>();
		
		if(bulletRef != null && droneRef != null)
		{
			if(bulletRef.tag == "Bullet")
			{
				if(!WeaponManager.Instance.abilities.Contains(WeaponManager.Instance.chainScr))
				{
					otherCollider.GetComponent<Bullet>().Deactivate();
					droneRef.health -= WeaponManager.Instance.Damage;	
				}
			}
		}
	}
	
	public void PlayerInnerTriggerEnter(Collider otherCollider)
	{
		if(otherCollider != null)
		{
			if(otherCollider.name == "DroneTrigger")
				otherCollider.transform.parent.GetComponent<Drone>().speed = -5f;
		}
	}
	
	private IEnumerator DroneAttack(Player player, Drone drone)
	{	
		drone.damagePlayer = true;
		
		yield return new WaitForSeconds(2.0f);
		
		player.health -= drone.damage;
		
		drone.damagePlayer = false;
	}
}

