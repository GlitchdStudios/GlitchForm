using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bullet : MonoBehaviour
{
	protected float time;
	protected Transform thisTransform;
	protected float lifeTime;

	public float projectileSpeed;

	void Awake()
	{
		thisTransform = transform;
		projectileSpeed = 300f;
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