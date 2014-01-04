using UnityEngine;
using System.Collections;

public class MachineGun : BaseEntity
{
	public GameObject projectilePrefab;
	public GameObject generalScrDummy;
	public GameObject[] clone;
	
	private int lastBullet;
	private Transform thisTransform;
	private Bullet bulletRef;
	private RofController[] rofController;
	
	void Awake()
	{
		WeaponManager.Instance.SetWeaponStats();

		rofController = new RofController[2];

		for (int i = 0; i < rofController.Length; i++)
		{
			rofController[i] = generalScrDummy.GetComponent<RofController>();
		}
			
		thisTransform = transform;
		clone = new GameObject[WeaponManager.Instance.Ammo]; 					// This needs to run before the projectiles are instantiated
		InstantiateProjectiles();
	}
	
	// Update is called once per frame
	void Update ()
	{
		WeaponManager.Instance.ChangeAbilitySet();

		if(Input.GetKey(KeyCode.Space))
		{   
			if(rofController[WeaponManager.Instance.AbilitySetIndex].IsInputLocked()){}

			else
			{
				SetNextBullet();
				ActivateProjectiles();
				rofController[WeaponManager.Instance.AbilitySetIndex].Lock();
			}
		}
	}
	
	
	private void InstantiateProjectiles()
	{
		for(int i = 0; i < clone.Length; i++)
		{
			clone[i] = (Instantiate(projectilePrefab, thisTransform.position, thisTransform.rotation) as GameObject);
			clone[i].SetActive(false);
		}
		
	}
	
	private void ActivateProjectiles()
	{
		if(clone[GetNextBullet()].activeSelf == false)
		{
			bulletRef = clone[GetNextBullet()].GetComponent<Bullet>();

			//Initialize Bullet variables
			bulletRef.projectileSpeed = WeaponManager.Instance.ProjectileSpeed;
			bulletRef.lifeTime = WeaponManager.Instance.LifeTime;
			WeaponManager.Instance.SetWeaponStats();
			bulletRef.Damage = 5;

			if(WeaponManager.Instance.CurAbilitySet.Contains(WeaponManager.Instance.chainScr))
			{
				bulletRef.SetAbilityStats(2f, -PickupManager.Instance.chainScr.speedReduction, -4, 5f);
			    (bulletRef.collider as SphereCollider).radius = 5f;
			}

			clone[GetNextBullet()].SetActive(true);
			bulletRef.GetComponent<Bullet>().Activate();
			clone[GetNextBullet()].transform.position = thisTransform.position;
		}   
	}
	
	private void SetNextBullet()
	{
		lastBullet += 1;
		if(lastBullet >= WeaponManager.Instance.Ammo -1)
		{
			lastBullet = 0;//reset the loop
		}
		
		// Debug.Log("LastBullet = " + lastBullet);
	}
	
	private int GetNextBullet()
	{
		return lastBullet;
	}
	
}