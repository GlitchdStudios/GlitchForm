using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bullet : MonoBehaviour
{
    private float time;
    private Transform thisTransform;
	private List<Ability> abilities = new List<Ability>();
	
	public bool inactive;
	
    void Awake()
    {
        thisTransform = transform;
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
		MoveProjectile();
        LifeSpan();
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
		if(abilities[0])
		{
			//do nothing
		}
		
		else if(abilities[(int)AbilityTypes.Chain])  // if chain ability
		{
			WeaponManager.Instance.chainScr.ActivateChainBullet(transform, otherCollider);
		}
	}
	
	public void OnTriggerStay(Collider col)
	{
		ActivateChain(col);
		inactive = true;
	}
}

