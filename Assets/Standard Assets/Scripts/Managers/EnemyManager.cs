using UnityEngine;
using System.Collections;

public class EnemyManager : Singleton<EnemyManager>
{
	public GameObject drone;
	public GameObject target;
	public Drone[] droneScr;
	public GameObject[] clone;
	
	private int numOfDrones;
	
	void Start()
	{
		numOfDrones = 1;
		
		droneScr = new Drone[numOfDrones];
		clone = new GameObject[numOfDrones];
		
		StartCoroutine("LoadandInit");
	}
	
	public IEnumerator LoadandInit()
	{
		for(int i = 0; i < numOfDrones; i++)
		{
			clone[i] = (Instantiate(drone, transform.position, Quaternion.identity) as GameObject);
			yield return new WaitForSeconds(1f);
		}
	}
}

