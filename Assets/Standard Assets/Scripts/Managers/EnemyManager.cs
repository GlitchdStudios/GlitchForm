using UnityEngine;
using System.Collections;

public class EnemyManager : Singleton<EnemyManager>
{
	public GameObject drone;
	public GameObject target;
	public Drone[] droneScr;
	public GameObject[] clone;
	public int numOfDrones;

	private int curNumOfDrones;

	void Start()
	{
		numOfDrones = 14;
		droneScr = new Drone[numOfDrones];
		clone = new GameObject[numOfDrones];
		
		StartCoroutine(InitAndSpawn());
	}

	public IEnumerator InitAndSpawn()
	{
		while(curNumOfDrones < numOfDrones)
		{
			yield return new WaitForSeconds(1f);
			SpawnDrones();
		}
	}

	public IEnumerator Spawn()
	{
		if(curNumOfDrones < numOfDrones)
		{
			yield return new WaitForSeconds(5f);
			SpawnDrones();
		}
	}

	public void SpawnDrones()
	{
		Instantiate(drone, transform.position, Quaternion.identity);
		curNumOfDrones++;
	}

	public int CurNumOfDrones { set { curNumOfDrones = value;} get { return curNumOfDrones; } }
}

