using UnityEngine;
using System.Collections;

public class CollisionManager : Singleton<CollisionManager>
{	
	public void PlayerTriggerEnter(Collider otherCollider, Transform trigger)
	{
		Drone droneRef = otherCollider.transform.parent.GetComponent<Drone>();
		Player playerRef = trigger.parent.GetComponent<Player>();
		
		if(otherCollider != null && trigger != null)
		{
			if(otherCollider.name == "DroneTrigger")
			{
				droneRef.speed = 0;		
				//otherCollider.transform.parent.parent = null;
			}	
		}
	}
	
	public void PlayerTriggerStay(Collider otherCollider, Transform trigger)
	{
		if(otherCollider != null)
		{
			if(otherCollider.name == "DroneTrigger")
			{	
				Drone droneRef = otherCollider.transform.parent.GetComponent<Drone>();
				Player playerRef = trigger.parent.GetComponent<Player>();
				
				otherCollider.transform.parent.RotateAround(trigger.position, Vector3.up, otherCollider.transform.parent.GetComponent<Drone>().Angle * Time.deltaTime);
				
				if(!droneRef.damagePlayer)
					StartCoroutine(DroneAttack(playerRef, droneRef));
				
				Debug.Log("Health: " + playerRef.health);
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
		
		if(otherCollider != null && trigger != null)
		{
			if(otherCollider.tag == "Bullet")
			{
				otherCollider.GetComponent<Bullet>().Deactivate();
				
				if(droneRef.health <= 0)
					Destroy(droneRef.gameObject);
				
				else
					droneRef.health -= WeaponManager.Damage;	
			}
			//Debug.Log("Col = " + otherCollider.name);
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

