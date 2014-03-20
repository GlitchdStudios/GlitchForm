using UnityEngine;
using System.Collections;

public class AsteroidManager : MonoBehaviour
{
	private Transform thisTransform;
	private GameObject[] clone;
	private int randIndex;

	public GameObject[] asteroid;
	public GameObject monsterRoid;

	// Use this for initialization
	void Start ()
	{
		thisTransform = transform;
		Toolbox.curPool = 0;
	}

	public void InitPool(EventStage eventStage)
	{
		switch(eventStage)
		{
			case EventStage.NORMAL:
				Toolbox.pool = 3;
			break;

			case EventStage.HARD:
				Toolbox.pool = 6;
			break;

			case EventStage.VERY_HARD:
				Toolbox.pool = 9;
			break;

			case EventStage.IMPOSSIBLE:
				Toolbox.pool = 12;
			break;

			case EventStage.NIGHTMARE:
				Toolbox.pool = 15;
			break;
		}

		clone = new GameObject[Toolbox.pool];
	}

	public IEnumerator CreateAsteroids()
	{
		if(clone != null)
		{
			for(int i = Toolbox.curPool; i < clone.Length; i++)
			{
				yield return new WaitForSeconds(Delay());
				randIndex = Random.Range(0, 6);
				clone[i] = (Instantiate(asteroid[randIndex], SpawnerPos(), Quaternion.identity) as GameObject);
				Toolbox.curPool++;
			}
		}
	}

	public void CreateMonsterRoid()
	{
		Instantiate(monsterRoid, thisTransform.position, Quaternion.identity);
	}
	
	public float Delay() 		{ Toolbox.delay = Random.Range(1f, 3f); return Toolbox.delay; }
	public Vector3 SpawnerPos() { Toolbox.spawnerPos = new Vector2(thisTransform.position.x + Random.Range(Toolbox.width/2 * -1, Toolbox.width/2), thisTransform.position.y);  return Toolbox.spawnerPos;}
}

