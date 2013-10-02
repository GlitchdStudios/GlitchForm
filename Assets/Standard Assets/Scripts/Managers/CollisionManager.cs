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
				
				Debug.Log("Health: " + player.GetComponent<Player>().health);
			}	
		}
	}
}

