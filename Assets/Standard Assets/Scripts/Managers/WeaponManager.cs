using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeaponManager : Singleton<WeaponManager>
{
	private int ammo = 20;
	private float lifeTime;
    private float rof;
	private float projectileSpeed;
	
	public GameObject bullet;
	public GameObject chain;
	public GameObject machineGun;
	public List<Ability> abilities = new List<Ability>();

	public MachineGun machineGunScr;
	public Bullet bulletScr;

	//Abilities
	public Chain chainScr;
	
	void Start()
	{
		chainScr = chain.GetComponent<Chain>();

		machineGunScr = machineGun.GetComponent<MachineGun>();
		bulletScr = bullet.GetComponent<Bullet>();
	}
	 
	public void SetWeaponStats()
	{
		rof = 0.2f;
		projectileSpeed = 10f;
		lifeTime = 2f;
	}

	public void SetAbilityStats(float rofChange, float speedChange, int damageChange, float lifeTimeChange)
	{
		rof += rofChange;
		projectileSpeed += speedChange;
		machineGunScr.Damage += damageChange;
		lifeTime += lifeTimeChange;
	}

	public int Ammo 				{ get {return ammo;}  }
	public float LifeTime 		{ get {return lifeTime;}  }
	
	public float RoF 				{ set { rof = value; } get {return rof;}  }
	public float ProjectileSpeed 	{ set { projectileSpeed = value; } get {return projectileSpeed;}  }
}

