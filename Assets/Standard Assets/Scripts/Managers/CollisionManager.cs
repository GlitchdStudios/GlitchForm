using UnityEngine;
using System.Collections;

public class CollisionManager : MonoBehaviour
{
	public static void PlayerTriggerEnter(Collider otherCollider, Transform trigger)
	{
		if(otherCollider != null && trigger != null)
		{
			if(otherCollider.tag == "Drone")
			{
				if(trigger.parent.GetComponent<Player>().health <= 0)
				{
					Destroy(trigger.transform.parent.gameObject);
				}
				
				else
					trigger.parent.GetComponent<Player>().health -= otherCollider.transform.parent.GetComponent<Drone>().damage;
					otherCollider.transform.parent.GetComponent<Drone>().speed = 0;
				
				Debug.Log("Col = " + otherCollider.name);
				
				//Debug.Log("Health: " + trigger.parent.GetComponent<Player>().health);
			}	
		}
	}
	
	public static void PlayerTriggerExit(Collider otherCollider)
	{
		if(otherCollider != null)
		{
			if(otherCollider.tag == "Drone")
			{
				otherCollider.transform.parent.GetComponent<Drone>().speed = 5f;
			}
		}
	}
	
	public static void DroneTriggerEnter(Collider otherCollider, GameObject droneTrigger)
	{
		if(otherCollider != null && droneTrigger != null)
		{
			if(otherCollider.tag == "Bullet")
			{
				otherCollider.GetComponent<Bullet>().Deactivate();
				
				if(droneTrigger.transform.parent.GetComponent<Drone>().health <= 0)
					Destroy(droneTrigger.transform.parent.gameObject);
				
				else
					droneTrigger.transform.parent.GetComponent<Drone>().health -= WeaponManager.Damage;	
			}
		}
	}
	
	public static void PlayerInnerTriggerEnter(Collider otherCollider)
	{
		if(otherCollider != null)
		{
			otherCollider.transform.parent.GetComponent<Drone>().speed = -5f;
			Debug.Log("speed: " + otherCollider.transform.parent.GetComponent<Drone>().speed); 

		}
	}
}

