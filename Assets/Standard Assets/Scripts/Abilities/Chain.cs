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
	   Drone drone = col.GetComponent<Drone>();

        if (drone != null)
        {
			drone.inactive = true;
          	drone.MoveDrone(drone.transform.position, location.position, drone.speed * Time.deltaTime);
        }
	}
}

