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
	   Drone drone = col.transform.parent.GetComponent<Drone>();

        if (drone != null)
        {
			if(!drone.inactive)
			{
				drone.inactive = true;
			}
			
			drone.targetPos = location.position;
        }
	}
}

