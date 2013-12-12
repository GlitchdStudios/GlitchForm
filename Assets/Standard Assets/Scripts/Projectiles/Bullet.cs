using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bullet : BaseEntity
{
	private float time;
	private Transform thisTransform;

	public List<Drone> passDroneRef;
	
	//State
	public BulletState bulletState;
	
	void Start()
	{
		thisTransform = transform;
		passDroneRef = new List<Drone>();
		bulletState = gameObject.GetComponent<BulletState>();
		
		if(WeaponManager.Instance.abilities.Contains(WeaponManager.Instance.chainScr))
		{
			(collider as SphereCollider).radius = 3f;
		}
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		MoveProjectile();
		LifeSpan();
	}
	
	void OnDisable()
	{	
		RevertState(passDroneRef);
	}
	
	private void MoveProjectile()
	{ 
		float movement = WeaponManager.Instance.ProjectileSpeed * Time.deltaTime;
		thisTransform.Translate(Vector3.up * movement);
	}
	
	public void Activate()
	{
		time = Time.time + WeaponManager.Instance.LifeTime;
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
	
	public void SetAbilities(Ability newAbilities) //Pass the abilities that are actively on the weapon
	{
		if(newAbilities != null)
			WeaponManager.Instance.abilities.Add(newAbilities);
	} 
	
	public void RevertState(List<Drone> droneRef)
	{
		for(int i = 0; i < droneRef.Count; i++)
		{	
			if(droneRef[i] != null)
			{
				droneRef[i].speed *= -1;
				droneRef[i].enemyState.CurDroneState = droneRef[i].enemyState.enemyMoving;
			}
		}
	}
	
	public void ActivateChain(Collider otherCollider)
	{	
		bulletState.chainActive.SetupChain(otherCollider, transform);
		bulletState.ActivateState();
	}
	
	public void OnTriggerEnter(Collider col)
	{
		Drone droneRef = col.transform.parent.GetComponent<Drone>();
		passDroneRef.Add(droneRef);
		
		if(droneRef != null)
		{ 
			if(WeaponManager.Instance.abilities.Contains(WeaponManager.Instance.chainScr))
			{
				bulletState.CurBulletState = bulletState.chainActive;
				droneRef.speed = 5f;
			}
		}
	}
	
	public void OnTriggerStay(Collider col)
	{
		ActivateChain(col);
	}
}