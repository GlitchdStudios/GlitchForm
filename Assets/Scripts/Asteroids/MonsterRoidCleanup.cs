using UnityEngine;
using System.Collections;

public class MonsterRoidCleanup	: MonoBehaviour
{
	public GameObject asteroidSpawner;

	void OnTriggerExit2D(Collider2D col)
	{
		if(col.tag == "MonsterRoid")
		{
			Destroy(col.gameObject);
			asteroidSpawner.SetActive(true);
			Toolbox.asteroidManager.InitPool(Toolbox.curEvent);
			StartCoroutine(Toolbox.asteroidManager.CreateAsteroids());
		}
	}
}

