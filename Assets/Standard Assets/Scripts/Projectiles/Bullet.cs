using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bullet : MonoBehaviour
{
    private float time;
    private Transform thisTransform;
	private List<Ability> abilities = new List<Ability>();
	
	public bool inactive;
	
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
		for(int i = 0; i < EnemyManager.Instance.clone.Length; i++)
		{
			EnemyManager.Instance.droneScr[i] = EnemyManager.Instance.clone[i].GetComponent<Drone>();
			if(!EnemyManager.Instance.droneScr[i].m_targetPlayer)
			{
				EnemyManager.Instance.droneScr[i].m_targetPlayer = true;
			}
		}
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
			abilities.Add(newAbilities);
	} 
	
	public void ActivateChain(Collider otherCollider)
	{	
		//if(abilities.Contains(WeaponManager.Instance.chainScr))  // if chain ability
		//{
			WeaponManager.Instance.chainScr.ActivateChainBullet(transform, otherCollider);
		//}
	}
	
	public void OnTriggerStay(Collider col)
	{
		ActivateChain(col);
		
		inactive = true;
	}
}

