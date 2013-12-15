using UnityEngine;
using System.Collections;

public class Chain : Ability
{
	private MachineGun machineGunRef;

	public float speedReduction;
	public GameObject machineGun;
	
	void Start()
	{
		machineGunRef = machineGun.GetComponent<MachineGun>();
		speedReduction = 7f;
	}

	public void ActivateChainBullet(Transform location, Collider col)
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
			StartCoroutine(ChainDot(drone));
        }
	}

	private IEnumerator ChainDot(Drone droneRef)
	{	
		yield return new WaitForSeconds(2.0f);
		droneRef.enemyState.CurGameObjStatus = StateManager.Instance.damaged;
		StateManager.Instance.damaged.Attacker = (BaseEntity)machineGunRef;
		StateManager.Instance.damaged.Defender = (BaseEntity)droneRef;
		droneRef.enemyState.ActivateStatus();
	}
}

