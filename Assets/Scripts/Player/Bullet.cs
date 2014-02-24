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
		projectileSpeed = 100f;
		lifeTime = 3f;
	}

	void Start()
	{
		//MoveProjectile();
	}

	// Update is called once per frame
	void FixedUpdate ()
	{
		LifeSpan();
	}
	
//	private void MoveProjectile()
//	{
//		rigidbody2D.AddForce(thisTransform.up * projectileSpeed);
//	}
	
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