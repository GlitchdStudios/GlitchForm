using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CollisionManager : Singleton<CollisionManager>
{	
	public GameObject player;
	
	public void PlayerTriggerEnter(Collider otherCollider, Transform trigger)
	{
		if(otherCollider != null && trigger != null)
		{
			if(otherCollider.name == "DroneTrigger")
			{
				Drone droneRef = otherCollider.transform.parent.GetComponent<Drone>();
				droneRef.enemyState.CurDroneState = droneRef.enemyState.orbiting;
				droneRef.speed = 0f;		
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
			Drone droneRef = otherCollider.transform.parent.GetComponent<Drone>();
			if(otherCollider.name == "DroneTrigger")
			{
				if(otherCollider != null && trigger != null)
				{
					Player playerRef = trigger.parent.GetComponent<Player>();
					
					//Orbiting
					droneRef.enemyState.orbiting.SetOrbit(otherCollider, trigger);
					droneRef.enemyState.ActivateState();
						
//					if(!droneRef.damagePlayer)
//						StartCoroutine(DroneAttack(playerRef, droneRef));
					
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
				Drone droneRef = otherCollider.transform.parent.GetComponent<Drone>();
				
				droneRef.speed = 5f;
				droneRef.enemyState.CurDroneState = droneRef.enemyState.enemyMoving;
			}
		}
	}
	
	public void DroneTriggerEnter(Collider otherCollider, Transform trigger)
	{
		Drone droneRef = trigger.transform.parent.GetComponent<Drone>();
		Bullet bulletRef = otherCollider.GetComponent<Bullet>();
		MachineGun machineGunRef = player.GetComponentInChildren<MachineGun>();
		
		if(bulletRef != null && droneRef != null && machineGunRef != null)
		{
			if(bulletRef.tag == "Bullet")
			{
				if(WeaponManager.Instance.abilities.Contains(WeaponManager.Instance.chainScr))
				{	
					droneRef.enemyState.enemyMoving.X = otherCollider.transform.position.x;
					droneRef.enemyState.enemyMoving.Z = otherCollider.transform.position.z;
				}

				else
				{
					otherCollider.GetComponent<Bullet>().Deactivate();
					
					droneRef.enemyState.CurGameObjStatus = StateManager.Instance.damaged;
					StateManager.Instance.damaged.Attacker = (BaseEntity)machineGunRef;
					StateManager.Instance.damaged.Defender = (BaseEntity)droneRef;
					droneRef.enemyState.ActivateStatus();
				}
			}
		}
	}
	
	public void PlayerInnerTriggerEnter(Collider otherCollider)
	{
		Drone droneRef = otherCollider.transform.parent.GetComponent<Drone>();
		if(otherCollider != null)
		{
			if(otherCollider.name == "DroneTrigger")
			{
				droneRef.speed = -5f;
				droneRef.enemyState.CurDroneState = droneRef.enemyState.enemyMoving;
			}
		}
	}
	
	private IEnumerator DroneAttack(Player player, Drone drone)
	{	
		drone.damagePlayer = true;
		
		yield return new WaitForSeconds(2.0f);
		
		player.Health -= drone.Damage;
		drone.damagePlayer = false;
	}
}

