using UnityEngine;
using System.Collections;

public class CollisionManager : Singleton<CollisionManager>
{
	public static void PlayerTriggerEnter(Collider otherCollider, Transform trigger)
	{
		if(otherCollider != null && trigger != null)
		{
			if(otherCollider.name == "DroneTrigger")
			{
				if(trigger.parent.GetComponent<Player>().health <= 0)
				{
					Destroy(trigger.transform.parent.gameObject);
				}
				
				else
					//Renable when you want to die!
					//trigger.parent.GetComponent<Player>().health -= otherCollider.transform.parent.GetComponent<Drone>().damage;
					otherCollider.transform.parent.GetComponent<Drone>().speed = 0;
				
				Debug.Log("Health: " + trigger.parent.GetComponent<Player>().health);
			}	
		}
	}
	
	public static void PlayerTriggerStay(Collider otherCollider, Transform trigger)
	{
		if(otherCollider != null)
		{
			if(otherCollider.name == "DroneTrigger")
			{
				otherCollider.transform.parent.RotateAround(trigger.position, Vector3.up, otherCollider.transform.parent.GetComponent<Drone>().Angle * Time.deltaTime); 
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
		if(otherCollider != null && trigger != null)
		{
			if(otherCollider.tag == "Bullet")
			{
				otherCollider.GetComponent<Bullet>().Deactivate();
				
				if(trigger.transform.parent.GetComponent<Drone>().health <= 0)
					Destroy(trigger.transform.parent.gameObject);
				
				else
					trigger.transform.parent.GetComponent<Drone>().health -= WeaponManager.Damage;	
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

}

