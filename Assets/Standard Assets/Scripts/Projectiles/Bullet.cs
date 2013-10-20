using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bullet : MonoBehaviour
{
    private float time;
    private Transform thisTransform;
	private List<Ability> abilities = new List<Ability>();
	
    void Awake()
    {
        thisTransform = transform;
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        LifeSpan();
        MoveProjectile();
    }

    private void MoveProjectile()
    {   
        float movement = WeaponManager.Instance.ProjectileSpeed * Time.deltaTime;
        thisTransform.Translate(Vector3.right * movement);
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
	
	public void SetAbilities(List<Ability> newAbilities) //Pass the abilities that are actively on the weapon
	{
		abilities.AddRange(newAbilities);
	} 
	
	public void ActivateAbilities()
	{
		if(abilities.Contains(WeaponManager.Instance.chain.GetComponent<Chain>()))  // if chain ability
		{
			//abilities[WeaponManager.Instance.AbilityTypes.Chain].
		}
	}
}

