using UnityEngine;
using System.Collections;

public class AsteroidCleanup : MonoBehaviour
{
	void OnTriggerExit2D(Collider2D col)
	{
		if(col.tag == "Asteroid")
		{
			col.gameObject.SetActive(false);
		
			if(AsteroidManager.Instance.gameObject.activeSelf == true)
			{
				AsteroidManager.Instance.SetNextAsteroid();
				col.gameObject.SetActive(true);
				col.transform.position = AsteroidManager.Instance.SpawnerPos();
			}
		}
	}
}

