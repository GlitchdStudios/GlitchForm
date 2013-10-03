using UnityEngine;
using System.Collections;

public class CollisionManager : MonoBehaviour
{
	public static void PlayerTriggerEnter(Collider otherCollider, GameObject player)
	{
		if(otherCollider != null && player != null)
		{
			if(otherCollider.tag == "Drone")
			{
				if(player.GetComponent<Player>().health <= 0)
				{
					Destroy(player);
				}
				
				else
					player.GetComponent<Player>().health -= otherCollider.GetComponent<Drone>().damage;
					otherCollider.GetComponent<Drone>().speed = 0f;
				
				Debug.Log("Health: " + player.GetComponent<Player>().health);
			}	
		}
	}
	
	public static void PlayerTriggerExit(Collider otherCollider)
	{
		if(otherCollider != null)
		{
			if(otherCollider.tag == "Drone")
			{
				otherCollider.GetComponent<Drone>().speed = 4f;
			}
		}
	}
	
	public static void BulletTriggerEnter(Collider otherCollider, GameObject drone)
	{
		if(otherCollider != null && drone != null)
		{
			if(otherCollider.tag == "Bullet")
			{
				otherCollider.GetComponent<Bullet>().Deactivate();
				
				if(drone.GetComponent<Drone>().health <= 0)
					Destroy(drone);
				
				else
					drone.GetComponent<Drone>().health -= WeaponManager.Damage;
			}
		}
	}
}

