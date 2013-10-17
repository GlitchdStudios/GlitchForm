using UnityEngine;
using System.Collections;

public class Chain : Ability
{
	private float radius;
	private int numOfChains;
	
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public bool EnemyInRadius(Transform bulletHitPos)
	{
		//Put code here (use Physics.OverlapSphere)
		
		return true;
	}
}

