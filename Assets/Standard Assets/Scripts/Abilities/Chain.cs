using UnityEngine;
using System.Collections;

public class Chain : Ability
{
	private float speedReduction;

	void Start()
	{
		speedReduction = 7f;
		WeaponManager.Instance.SetAbilityStats(0, -speedReduction, 0, 5f);
	}

	public void ActivateChainBullet(Transform location, Collider col)
	{	
		if (col != null && location != null)
        {
			Bullet bullet = location.GetComponent<Bullet>();
			Drone drone = col.transform.parent.GetComponent<Drone>();
			
			if(drone.enemyState.CurDroneState == drone.enemyState.chained)
			{
				drone.enemyState.ActivateState();
			}
			else
			{
				drone.enemyState.chained.Setup(location);
				drone.enemyState.CurDroneState = drone.enemyState.chained;
			}
        }
	}
}

