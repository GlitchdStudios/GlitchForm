using UnityEngine;
using System.Collections;

public class Chain : Ability
{
	private int numOfChains;
	
	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void ActivateChainBullet(Transform location, Collider col)
	{	
		if (col != null && location != null)
        {
	    	Drone drone = col.transform.parent.GetComponent<Drone>();
			Bullet bullet = location.GetComponent<Bullet>();
	   
			drone.TargetBullet(location.position.x, location.position.z, false);
			
			bullet.inactive = true;
        }
	}
}

