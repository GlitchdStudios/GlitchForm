using UnityEngine;
using System.Collections;

public class EnemyManager : Singleton<EnemyManager>
{
	public GameObject drone;
	public GameObject target;
	
	void Start()
	{
		StartCoroutine("LoadandInit");
	}
	
	public IEnumerator LoadandInit()
	{
		for(int i = 0; i < 10; i++)
		{
			Instantiate(drone, transform.position, Quaternion.identity);
			yield return new WaitForSeconds(1f);
		}
	}
}

