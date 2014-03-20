using UnityEngine;
using System.Collections;

public enum BulletType { BULLET=0, SUPER_BULLET }

public class Turret : MonoBehaviour
{
	private AngularMovement angularMove;
	private EnergyBar energyBar;
	private Bullet bulletRef;
	private TriggerHandler triggerHandler;
	private int lastBullet;
	private int lastSuperBullet;
	private Transform thisTransform;
	private Transform weaponTransform;
	private bool locked;
	private float offset;

	public int ammo;
	public int heavyAmmo;
	public float rof;
	public GameObject bulletPrefab;
	public GameObject superBulletPrefab;
	public GameObject[] clone;
	public GameObject[] altClone;
	public GameObject turretBaseObj;
	public GameObject weapon;


	void Awake()
	{
		thisTransform = transform;
		ammo = 30;
		heavyAmmo = 15;
		clone = new GameObject[ammo]; 					// This needs to run before the projectiles are instantiated
		altClone = new GameObject[heavyAmmo];
		InstantiateProjectiles();
	}

	// Use this for initialization
	void Start ()
	{
		triggerHandler = GetComponent<TriggerHandler>();
		angularMove = GetComponent<AngularMovement>();
		energyBar = GetComponentInChildren<EnergyBar>();
		weaponTransform = weapon.GetComponent<Transform>();
	}

	// Update is called once per frame
	void FixedUpdate ()
	{
		angularMove.PointAtCursor();

		if(Input.touchCount > 0)
		{   
			if(IsInputLocked()){}
			
			else
			{	
				switch(triggerHandler.BulletState)
				{
					case BulletType.BULLET:
						if(energyBar.Energy > energyBar.MinEnergy(triggerHandler.BulletState))
						{	
							SetNextBullet();
							ActivateProjectiles(triggerHandler.BulletState);
						}
					break;

					case BulletType.SUPER_BULLET:
						if(energyBar.Energy > energyBar.MinEnergy(triggerHandler.BulletState))
						{
							SetNextSuperBullet();
							ActivateProjectiles(triggerHandler.BulletState);
						}
					break;
				}
				energyBar.UseEnergy(triggerHandler.BulletState);
				Lock();
			}
		}
	}

	private void Lock()
	{
		locked = true;

		Invoke("Unlock", rof);
	}
	
	private void Unlock()
	{
		locked = false;
	}
	
	private bool IsInputLocked()
	{
		return locked;
	}	
	
	private void InstantiateProjectiles()
	{
		for(int i = 0; i < clone.Length; i++)
		{
			clone[i] = (Instantiate(bulletPrefab, thisTransform.position, thisTransform.rotation) as GameObject);
			clone[i].SetActive(false);
		}

		for(int i = 0; i < altClone.Length; i++)
		{
			altClone[i] = (Instantiate(superBulletPrefab, thisTransform.position, thisTransform.rotation) as GameObject);
			altClone[i].SetActive(false);
		}
	}

	private void ActivateProjectiles(BulletType bulletType)
	{
		switch(bulletType)
		{
			case BulletType.BULLET:
				if(clone[GetNextBullet()].activeSelf == false)
				{
					bulletRef = clone[GetNextBullet()].GetComponent<Bullet>();
					
					rof = 0.2f;
					clone[GetNextBullet()].SetActive(true);
					bulletRef.GetComponent<Bullet>().Activate();
					clone[GetNextBullet()].transform.position = weaponTransform.position;
					clone[GetNextBullet()].transform.rotation = weaponTransform.rotation;
					clone[GetNextBullet()].rigidbody2D.AddForce(bulletRef.transform.up * bulletRef.projectileSpeed);
				}
			break;

			case BulletType.SUPER_BULLET:
				if(altClone[GetNextSuperBullet()].activeSelf == false)
				{
					bulletRef = altClone[GetNextSuperBullet()].GetComponent<SuperBullet>();
					
					rof = 0.4f;
					altClone[GetNextSuperBullet()].SetActive(true);
					bulletRef.GetComponent<SuperBullet>().Activate();
					altClone[GetNextSuperBullet()].transform.position = weaponTransform.position;
					altClone[GetNextSuperBullet()].transform.rotation = weaponTransform.rotation;
					altClone[GetNextSuperBullet()].rigidbody2D.AddForce(bulletRef.transform.up * bulletRef.projectileSpeed);
				}
			break;
		}
	}

	private void SetNextBullet()
	{
		lastBullet += 1;
		if(lastBullet >= ammo -1)
		{
			lastBullet = 0;//reset the loop
		}
		
		// Debug.Log("LastBullet = " + lastBullet);
	}

	private int GetNextBullet()
	{
		return lastBullet;
	}	

	private void SetNextSuperBullet()
	{
		lastSuperBullet += 1;
		if(lastSuperBullet >= heavyAmmo -1)
		{
			lastSuperBullet = 0;//reset the loop
		}
	}
	
	private int GetNextSuperBullet()
	{
		return lastSuperBullet;
	}
}

