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
				if(playerRef.health <= 0)
				{
					Destroy(playerRef.gameObject);
				}
				
				else
					//Renable when you want to die!
					droneRef.speed = 0;
				
				//otherCollider.transform.parent.parent = null;
				
				Debug.Log("Health: " + playerRef.health);
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
				StartCoroutine(DroneAttack(playerRef, droneRef));
			}
		}
	}
	
	public static void PlayerTriggerExit(Collider otherCollider)
	{	
		if(otherCollider != null)
		{
			if(otherCollider.name == "DroneTrigger")
			{
				otherCollider.transform.parent.GetComponent<Drone>().speed = 5f;
			}
		}
	}
	
	public static void DroneTriggerEnter(Collider otherCollider, Transform trigger)
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
	
	public static void PlayerInnerTriggerEnter(Collider otherCollider)
	{
		if(otherCollider != null)
		{
			if(otherCollider.name == "DroneTrigger")
				otherCollider.transform.parent.GetComponent<Drone>().speed = -5f;
		}
	}
	
	private static IEnumerator DroneAttack(Player player, Drone drone)
	{	
		yield return new WaitForSeconds(10f);
		
		player.health -= drone.damage;
	}
}

