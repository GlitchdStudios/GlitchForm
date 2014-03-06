using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bullet : MonoBehaviour
{
	public float time;
	public Transform thisTransform;
	public float projectileSpeed;
	public float lifeTime;

	void Awake()
	{
		thisTransform = transform;
		projectileSpeed = 500f;
		lifeTime = 3f;
	}

	// Update is called once per frame
	void FixedUpdate ()
	{
		LifeSpan();
	}
	
	public void Activate()
	{
		time = Time.time + lifeTime;
	}
	
	public void Deactivate()
	{
		gameObject.SetActive(false);
	}
	
	private void LifeSpan()
	{
		if(time <= Time.time)
		{
			Deactivate();
		}
	}
}