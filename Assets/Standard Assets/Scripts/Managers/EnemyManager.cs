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

	public int CurNumOfDrones { set { curNumOfDrones = value;} get { return curNumOfDrones; } }
}

