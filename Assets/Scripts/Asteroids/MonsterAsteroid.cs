using UnityEngine;
using System.Collections;

public class MonsterAsteroid : Asteroid
{
	// Use this for initialization
	void Start ()
	{
		thisTransform = transform;
		randRotation = 3;
		rotation = new Vector3(Random.Range(-randRotation,randRotation),Random.Range(-randRotation,randRotation), Random.Range(-randRotation,randRotation));
		randomScale = Random.Range(2f,2.5f);
		scale = new Vector3(randomScale, randomScale, randomScale);
	}

	// Update is called once per frame
	void Update ()
	{
		thisTransform.Rotate(rotation.x, rotation.y, rotation.z);
		thisTransform.localScale = scale;
	}
}

