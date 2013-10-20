using UnityEngine;
using System.Collections;

public class WeaponManager : Singleton<WeaponManager>
{
	private int ammo = 20;
	private float lifeTime = 2.0f;
    private float rof;
	private float projectileSpeed;
	private int damage;
	
	public GameObject bullet;
	public GameObject chain;
	 
	public void SetWeaponStats(GameObject gameObject)
	{
		switch(gameObject.name)
		{
			case "MachineGun":
					rof = 0.1f;
					projectileSpeed = 10f;
					damage = 5;
			break;
					
		}
	}
	
	public int Ammo 				{ get {return ammo;}  }
	public float LifeTime 		{ get {return lifeTime;}  }
	public int Damage			{ get {return damage;} }
	
	public float RoF 				{ set { rof = value; } get {return rof;}  }
	public float ProjectileSpeed 	{ set { projectileSpeed = value; } get {return projectileSpeed;}  }
}

