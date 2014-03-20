using UnityEngine;
using System.Collections;

public class Cloud : MonoBehaviour
{
	private Transform thisTransform;
	private int randIndex;
	private Vector3 spawnerPos;
	
	public GameObject[] cloud;

	// Use this for initialization
	void Start ()
	{
		thisTransform = transform;

		StartCoroutine(CreateClouds());
	}

	public IEnumerator CreateClouds()
	{
		yield return new WaitForSeconds(Delay());
		randIndex = Random.Range(0, 2);
		Instantiate(cloud[randIndex], SpawnerPos(), Quaternion.identity);
		StartCoroutine(CreateClouds());
	}
	
	public float Delay() 		{ Toolbox.delay = Random.Range(1f, 3f); return Toolbox.delay; }
	public Vector3 SpawnerPos() { spawnerPos = new Vector3(thisTransform.position.x, thisTransform.position.y + Random.Range(2 * Camera.main.orthographicSize/2 * -1, 2 * Camera.main.orthographicSize/2), thisTransform.position.z);  return spawnerPos;}
}


