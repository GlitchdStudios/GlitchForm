using UnityEngine;
using System.Collections;

public class EnemyManager : Singleton<EnemyManager>
{
	public GameObject drone;
	public GameObject target;
	public float droneHeight;
	public Drone[] droneScr;
	public GameObject[] clone;
	
	private int numOfDrones;
	
	void Start()
	{
		numOfDrones = 1;
		droneHeight = -5;
		
		droneScr = new Drone[numOfDrones];
		clone = new GameObject[numOfDrones];
		
		StartCoroutine("LoadandInit");
	}
	
	public IEnumerator LoadandInit()
	{
		for(int i = 0; i < numOfDrones; i++)
		{
			clone[i] = (Instantiate(drone, transform.position, Quaternion.identity) as GameObject);
			InitDroneHeight(i);
			yield return new WaitForSeconds(1f);
		}
	}
	
	public void InitDroneHeight(int index)
	{
		droneHeight += 0.5f;
		
		clone[index].GetComponent<EnemyMoving>().height = droneHeight;
		clone[index].GetComponent<Chained>().height = droneHeight;
	}
}

