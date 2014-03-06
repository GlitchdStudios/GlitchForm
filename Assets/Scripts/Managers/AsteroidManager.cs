using UnityEngine;
using System.Collections;

public class AsteroidManager : Singleton<AsteroidManager>
{
	private float delay;
	private float gameTime;
	private Vector3 spawnerPos;
	private float height;
	private float width;
	private Transform thisTransform;
	private int index;
	private int pool;
	private GameObject[] clone;
	private int lastAsteroid;

	public GameObject[] asteroid;
	public GameObject monsterRoid;
	
	// Use this for initialization
	void Start ()
	{
		thisTransform = transform;
		pool = 5;
		clone = new GameObject[pool];
		height = 2 * Camera.main.orthographicSize;
		width = height * Camera.main.aspect;
	}

	public IEnumerator CreateAsteroids(EventStage eventStage)
	{
		switch(eventStage)
		{
			case EventStage.NORMAL:
				for(int i = 0; i < clone.Length; i++)
				{
					yield return new WaitForSeconds(Delay());
					index = Random.Range(0, 6);
					clone[i] = (Instantiate(asteroid[index], SpawnerPos(), Quaternion.identity) as GameObject);
				}
			break;

			case EventStage.HARD:
				pool = 15;
				for(int i = 0; i < clone.Length; i++)
				{
					yield return new WaitForSeconds(Delay());
					index = Random.Range(0, 6);
					clone[i] = (Instantiate(asteroid[index], SpawnerPos(), Quaternion.identity) as GameObject);
				}
			break;
		}

	}

	public void CreateMonsterRoid()
	{
		Instantiate(monsterRoid, thisTransform.position, Quaternion.identity);
	}

	public void SetNextAsteroid()
	{
		lastAsteroid += 1;
		if(lastAsteroid >= pool -1)
		{
			lastAsteroid = 0;//reset the loop
		}
	}

	public int GetNextAsteroid()
	{
		return lastAsteroid;
	}

	public float Delay() 		{ delay = Random.Range(1f, 3f); return delay; }
	public Vector3 SpawnerPos() { spawnerPos = new Vector3(thisTransform.position.x + Random.Range(width/2 * -1, width/2), thisTransform.position.y);  return spawnerPos;}
}

