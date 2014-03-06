using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour
{
	protected Vector3 scale;
	protected float randomScale;
	protected Vector3 rotation;
	protected Transform thisTransform;

	// Use this for initialization
	void Start ()
	{
		InitRandom();
		thisTransform = transform;
	}

	// Update is called once per frame
	void Update ()
	{
		thisTransform.Rotate(rotation.x, rotation.y, rotation.z);
		thisTransform.localScale = scale;
	}

	public void InitRandom()
	{
		rotation = new Vector3(Random.Range(-5,5),Random.Range(-5,5), Random.Range(-5,5));
		randomScale = Random.Range(0.5f,1f);
		scale = new Vector3(randomScale, randomScale, randomScale);
	}	
}


