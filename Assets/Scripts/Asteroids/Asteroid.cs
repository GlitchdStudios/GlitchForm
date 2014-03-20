using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour
{
	protected Vector3 scale;
	protected float randomScale;
	protected Vector3 rotation;
	protected Transform thisTransform;
	protected int randRotation;
	protected Vector2 dir;

	// Use this for initialization
	void Start ()
	{
		randRotation = 3;
		InitRandom();
		thisTransform = transform;
		dir = new Vector2((Toolbox.turretScr.transform.position.x - thisTransform.position.x), (Toolbox.turretScr.transform.position.y - thisTransform.position.y));
		rigidbody2D.AddForce(dir * 200f);
	}

	// Update is called once per frame
	void Update ()
	{
		thisTransform.Rotate(rotation.x, rotation.y, rotation.z);
		thisTransform.localScale = scale;
	}

	public void InitRandom()
	{
		rotation = new Vector3(Random.Range(-randRotation,randRotation),Random.Range(-randRotation,randRotation), Random.Range(-randRotation,randRotation));
		randomScale = Random.Range(0.5f,1f);
		scale = new Vector3(randomScale, randomScale, randomScale);
	}	
}


