using UnityEngine;
using System.Collections;

public class MonsterAsteroid : Asteroid
{
	// Use this for initialization
	void Start ()
	{
		thisTransform = transform;
		rotation = new Vector3(Random.Range(-5,5),Random.Range(-5,5), Random.Range(-5,5));
		randomScale = Random.Range(3f,4f);
		scale = new Vector3(randomScale, randomScale, randomScale);
	}

	// Update is called once per frame
	void Update ()
	{
		thisTransform.Rotate(rotation.x, rotation.y, rotation.z);
		thisTransform.localScale = scale;
	}
}

