using UnityEngine;
using System.Collections;

public class MonsterRoidCleanup	: MonoBehaviour
{
	void OnTriggerExit2D(Collider2D col)
	{
		if(col.tag == "MonsterRoid")
		{
			Destroy(col.gameObject);
			StartCoroutine(AsteroidManager.Instance.CreateAsteroids(EventStage.HARD));
			AsteroidManager.Instance.gameObject.SetActive(true);
		}
	}
}

