using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour
{
	public GameObject drone;
	public GameObject target;
	private GameObject clone;
	
	void Start()
	{
		StartCoroutine("LoadandInit");
	}
	
	public IEnumerator LoadandInit()
	{
		for(int i = 0; i < 10; i++)
		{
			clone = Instantiate(drone, transform.position, Quaternion.identity) as GameObject;
			yield return new WaitForSeconds(1f);
		}
	}
}

