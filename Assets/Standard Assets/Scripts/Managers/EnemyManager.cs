using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour
{
	public GameObject drone;
	public GameObject target;
	
	void Start()
	{
		StartCoroutine("LoadandInit");
	}
	
	public IEnumerator LoadandInit()
	{
		for(int i = 0; i < 4; i++)
		{
			Instantiate(drone, transform.position, Quaternion.identity);
			yield return new WaitForSeconds(1f);
		}
	}
}

