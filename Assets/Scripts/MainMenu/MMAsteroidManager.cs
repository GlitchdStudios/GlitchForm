using UnityEngine;
using System.Collections;

public class MMAsteroidManager : Singleton<MMAsteroidManager>
{
	private float delay;
	private Vector3 spawnerPos;
	private float height;
	private float width;
	private Transform thisTransform;
	private int index;
	private int pool;
	private GameObject[] clone;
	private int lastAsteroid;

	public GameObject[] asteroid;
	
	// Use this for initialization
	void Start ()
	{
		thisTransform = transform;
		pool = 5;
		clone = new GameObject[pool];
		height = 2 * Camera.main.orthographicSize;
		width = height * Camera.main.aspect;

		StartCoroutine(CreateAsteroids());
	}

	public IEnumerator CreateAsteroids()
	{
		for(int i = 0; i < clone.Length; i++)
		{
			yield return new WaitForSeconds(Delay());
			index = Random.Range(0, 6);
			clone[i] = (Instantiate(asteroid[index], SpawnerPos(), Quaternion.identity) as GameObject);
		}
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

