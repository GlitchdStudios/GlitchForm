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
				if(droneRef.enemyState.CurDroneState != droneRef.enemyState.chained)
				{
					droneRef.enemyState.CurDroneState = droneRef.enemyState.orbiting;

					droneRef.enemyState.CurMovementDirState = droneRef.enemyState.stopped;
					droneRef.enemyState.ActivateMovementDirState(droneRef);
				}
			}
			
			if(otherCollider.name == "Chain")
			{
				WeaponManager.Instance.bulletScr.SetAbilities(PickupManager.Instance.abilityCollection[(int)AbilityTypes.Chain]);
				WeaponManager.Instance.SetAbilityStats(2f, -PickupManager.Instance.chainScr.speedReduction, -4, 5f);
				Destroy(otherCollider.gameObject);
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
					if(droneRef.enemyState.CurDroneState != droneRef.enemyState.chained)
					{
						Player playerRef = trigger.parent.GetComponent<Player>();
						float dist = Vector3.Distance(otherCollider.transform.position, trigger.position);

						if(dist <= 2.0f && droneRef.enemyState.CurDroneState != droneRef.enemyState.chained)
						{
							droneRef.enemyState.CurMovementDirState = droneRef.enemyState.backward;
							droneRef.enemyState.ActivateMovementDirState(droneRef);

							droneRef.enemyState.CurDroneState = droneRef.enemyState.enemyMoving;
						}

						//Orbiting
						droneRef.enemyState.orbiting.SetOrbit(otherCollider, trigger);
						droneRef.enemyState.ActivateState();
						
						if(!droneRef.damagePlayer)
							StartCoroutine(DroneAttack(playerRef, droneRef));
						
						//Debug.Log("Health: " + playerRef.health);
					}
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

				if(droneRef.enemyState.CurDroneState != droneRef.enemyState.chained)
				{
					droneRef.enemyState.CurDroneState = droneRef.enemyState.enemyMoving;

					droneRef.enemyState.CurMovementDirState = droneRef.enemyState.forward;
					droneRef.enemyState.ActivateMovementDirState(droneRef);
				}
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
				if(!WeaponManager.Instance.abilities.Contains(WeaponManager.Instance.chainScr))
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
	
	private IEnumerator DroneAttack(Player player, Drone drone)
	{	
		drone.damagePlayer = true;
		
		yield return new WaitForSeconds(2.0f);
		
		player.Health -= drone.Damage;
		drone.damagePlayer = false;                                                                                                            
	}
}
