using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bullet : MonoBehaviour
{
    private float time;
    private Transform thisTransform;
	
	public bool inactive;
	public AbstractState absState;
	
	void Start()
	{
		thisTransform = transform;
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
		
		for(int i = 0; i < EnemyManager.Instance.clone.Length; i++)
		{
			if(EnemyManager.Instance.clone[i] != null)
			{
				EnemyManager.Instance.droneScr[i] = EnemyManager.Instance.clone[i].GetComponent<Drone>();
				
				if(!CurBulletState == StateManager.Instance.chainActive)
				{
					EnemyManager.Instance.droneScr[i].CurDroneState = StateManager.Instance.orbiting;
				}
			}
		}
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
	
	public void ActivateState()
	{
		if(CurBulletState != null)
		{
			CurBulletState.ResolveState();
		}
	}
	
	public AbstractState CurBulletState { get { return absState;} set { absState = value; }}
	
	public void ActivateChain(Collider otherCollider)
	{	
		StateManager.Instance.chainActive.SetupChain(otherCollider, transform);
		ActivateState();
	}
	
	public void OnTriggerEnter(Collider col)
	{
		CurBulletState = StateManager.Instance.chainActive;
	}
	
	public void OnTriggerStay(Collider col)
	{
		ActivateChain(col);
	}
}

