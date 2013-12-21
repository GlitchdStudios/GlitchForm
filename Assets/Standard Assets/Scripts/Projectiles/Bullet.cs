using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bullet : BaseEntity
{
	public float time;
	public Transform thisTransform;
	public float projectileSpeed;
	public float lifeTime;

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
			(collider as SphereCollider).radius = 5f;
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
		float movement = projectileSpeed * Time.deltaTime;
		thisTransform.Translate(Vector3.up * movement);
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
				droneRef[i].enemyState.CurDroneState = droneRef[i].enemyState.enemyMoving;
				droneRef[i].enemyState.CurMovementDirState = droneRef[i].enemyState.backward;
				droneRef[i].enemyState.ActivateMovementDirState((BaseEntity)droneRef[i]);
			}
		}
	}
	
	public void ActivateChain(Collider otherCollider)
	{	
		bulletState.chainActive.SetupChain(otherCollider, transform);
		bulletState.ActivateState();
	}

	public void SetAbilityStats(float rofChange, float speedChange, int damageChange, float lifeTimeChange)
	{
		WeaponManager.Instance.RoF += rofChange;
		projectileSpeed += speedChange;
		baseDamage += damageChange;
		lifeTime += lifeTimeChange;
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
				droneRef.enemyState.CurMovementDirState = droneRef.enemyState.forward;
				droneRef.enemyState.ActivateMovementDirState((BaseEntity)droneRef);
			}
		}
	}
	
	public void OnTriggerStay(Collider col)
	{
		ActivateChain(col);
	}
}