using UnityEngine;
using System.Collections;

public class EnemyManager : Singleton<EnemyManager>
{
	public GameObject drone;
	public GameObject target;
	public Drone[] droneScr;
	public GameObject[] clone;

	public int curNumOfDrones;
	public int numOfDrones;
	
	void Start()
	{
		numOfDrones = 10;
		droneScr = new Drone[numOfDrones];
		clone = new GameObject[numOfDrones];
		
		StartCoroutine(LoadandInit());
	}

	public IEnumerator LoadandInit()
	{
		while(curNumOfDrones < numOfDrones)
		{
			SpawnDrones();
			yield return new WaitForSeconds(1f);
		}
		curNumOfDrones = numOfDrones;
	}

	public void SpawnDrones()
	{
		if(curNumOfDrones < numOfDrones)
		{
			Instantiate(drone, transform.position, Quaternion.identity);
			curNumOfDrones++;
		}
	}
}

