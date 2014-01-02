using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeaponManager : Singleton<WeaponManager>
{
	private int ammo = 20;
	private float lifeTime;
	private float rof;
	private float projectileSpeed;
	private float cooldown;
	private List<Ability>[] abilities = new List<Ability>[2];
	private List<Ability> curAbilityList = new List<Ability>();

	public GameObject bullet;
	public GameObject chain;
	public GameObject machineGun;

	public MachineGun machineGunScr;
	public Bullet bulletScr;
	
	//Abilities
	public Chain chainScr;
	
	void Start()
	{
		cooldown = 0.2f; 

		for (int i = 0; i < abilities.Length; i++)
		{
			abilities[i] = new List<Ability>();
		}

		curAbilityList = abilities[0];

		chainScr = chain.GetComponent<Chain>();
		machineGunScr = machineGun.GetComponent<MachineGun>();
		bulletScr = bullet.GetComponent<Bullet>();
	}

	void Update()
	{
		ChangeAbilitySet();
	}

	public void SetWeaponStats()
	{
		rof = 0.2f;
		projectileSpeed = 10f;
		lifeTime = 2f;
	}

	public void ChangeAbilitySet()
	{
		if(Input.GetKeyUp("1"))
		{
			Debug.Log("Number 1");
			curAbilityList = abilities[0];
		}

		if(Input.GetKeyUp("2"))
		{
			Debug.Log("Number 2");
			curAbilityList = abilities[1];
		}
	}

	public int Ammo 				{ get {return ammo;}  }
	public float LifeTime 		{ get {return lifeTime;}  }
	
	public float RoF 				{ set { rof = value; } get {return rof;}  }
	public float ProjectileSpeed 	{ set { projectileSpeed = value; } get {return projectileSpeed;}  }

	public List<Ability> CurAbilitySet {get { return curAbilityList; } }
}
