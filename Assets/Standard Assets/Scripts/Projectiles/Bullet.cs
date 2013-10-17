using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    private float time;
    private Transform thisTransform;

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
	
	public void SetAbilities() {} //Pass the abilities that a weapon has
}

