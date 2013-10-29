using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeaponManager : Singleton<WeaponManager>
{
	private int ammo = 20;
	private float lifeTime = 2.0f;
    private float rof;
	private float projectileSpeed;
	private int damage;
	
	public GameObject machineGun;
	public GameObject bullet;
	public GameObject chain;
	public List<Ability> abilities = new List<Ability>();
	
	//Abilities
	public Chain chainScr;
	public Bullet bulletScr;
	
	void Start()
	{
		chainScr = WeaponManager.Instance.chain.GetComponent<Chain>();
		bulletScr = WeaponManager.Instance.bullet.GetComponent<Bullet>();
	}
	 
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

