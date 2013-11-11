using UnityEngine;
using System.Collections;

public class Chain : Ability
{
	private int numOfChains;

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
				drone.enemyState.chained.Setup(col, location);
				drone.enemyState.CurDroneState = drone.enemyState.chained;
			}
			
			bullet.inactive = true;
        }
	}
}

