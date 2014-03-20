using UnityEngine;
using System.Collections;

public class AsteroidCleanup : MonoBehaviour
{
	public GameObject asteroidSpawner;

	void OnTriggerExit2D(Collider2D col)
	{
		if(col.tag == "Asteroid")
		{
			if(asteroidSpawner.activeSelf == true)
			{
				col.gameObject.SetActive(false);
				col.transform.position = Toolbox.asteroidManager.SpawnerPos();
				col.gameObject.SetActive(true);

				StartCoroutine(Toolbox.cameraShake.ShakeCamera());
			}

			else
			{
				Destroy(col.gameObject);
				Toolbox.curPool--;
				StartCoroutine(Toolbox.cameraShake.ShakeCamera());
			}
		}

		if(col.tag == "Clouds")
		{
			Destroy(col.gameObject);
		}
	}
}

