using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bullet : MonoBehaviour
{
    private float time;
    private Transform thisTransform;
	
	public bool inactive;
	public List<Drone> passDroneRef;
	
	void Start()
	{
		thisTransform = transform;
		passDroneRef = new List<Drone>();
	}

    // Update is called once per frame
    void FixedUpdate ()
    {
		MoveProjectile();
        LifeSpan();
    }
	
	void OnDisable()
	{
		if(inactive)
		{
			for(int i = 0; i < EnemyManager.Instance.clone.Length; i++)
			{
				if(EnemyManager.Instance.clone[i] != null)
				{
					EnemyManager.Instance.droneScr[i] = EnemyManager.Instance.clone[i].GetComponent<Drone>();
				
					if(!EnemyManager.Instance.droneScr[i].m_targetPlayer)
					{
						EnemyManager.Instance.droneScr[i].m_targetPlayer = true;
					}
				}
			}
		}
		
		RevertState(passDroneRef);
		
		inactive = false;
	}

    private void MoveProjectile()
    { 
		if(inactive == false)
		{
	        float movement = WeaponManager.Instance.ProjectileSpeed * Time.deltaTime;
	        thisTransform.Translate(Vector3.right * movement);
		}
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
				droneRef[i].enemyState.CurDroneState = droneRef[i].enemyState.orbiting;
				droneRef[i].speed *= -1;
				
				if(gameObject.activeSelf)
				{
					StartCoroutine(droneRef[i].ResetSpeed());
				}
			}
		}
	}
	
	public void ActivateChain(Collider otherCollider)
	{	
		Drone droneRef = otherCollider.transform.parent.GetComponent<Drone>();
		
		StateManager.Instance.chainActive.SetupChain(otherCollider, transform);
		droneRef.enemyState.ActivateState();
	}
	
	public void OnTriggerEnter(Collider col)
	{
		Drone droneRef = col.transform.parent.GetComponent<Drone>();
		passDroneRef.Add(droneRef);
		
		if(droneRef != null)
		{ 
			if(WeaponManager.Instance.abilities.Contains(WeaponManager.Instance.chainScr))
			{
				droneRef.enemyState.CurDroneState = StateManager.Instance.chainActive;
				droneRef.speed = 5f;
			}
		}
	}
	
	public void OnTriggerStay(Collider col)
	{
		ActivateChain(col);
	}
}

