using UnityEngine;
using System.Collections;

public class Chain : Ability
{
	public float speedReduction;
	
	void Start()
	{
		speedReduction = 7f;
	}

	public void ActivateChainBullet(Transform location, Collider2D col)
	{	
		if (col != null && location != null)
        {
			Bullet bullet = location.GetComponent<Bullet>();
			Drone drone = col.transform.parent.GetComponent<Drone>();

			if(drone.enemyState.CurDroneState != drone.enemyState.chained)
			{
				drone.enemyState.chained.Setup(location);
				drone.enemyState.CurDroneState = drone.enemyState.chained;
			}
        }
	}

	public void ChainOrbit(Drone droneRef, Bullet bulletRef)
	{
		StartCoroutine(ChainDot(droneRef, bulletRef));
	}

	private IEnumerator ChainDot(Drone droneRef, Bullet bulletRef)
	{	
		if(droneRef.enemyState.CurDroneState = droneRef.enemyState.chained)
		{
			yield return new WaitForSeconds(1.0f);
			droneRef.enemyState.CurGameObjStatus = StateManager.Instance.damaged;
			StateManager.Instance.damaged.Attacker = (BaseEntity)bulletRef;
			StateManager.Instance.damaged.Defender = (BaseEntity)droneRef;
			droneRef.enemyState.ActivateStatus();
		}
	}
}

