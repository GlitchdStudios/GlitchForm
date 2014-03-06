using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour
{
	private AngularMovement angularMove;
	private EnergyBar energyBar;
	private int lastBullet;
	private Transform thisTransform;
	private Bullet bulletRef;
	private bool locked;
	private float offset;

	public int ammo;
	public float rof;
	public GameObject bulletPrefab;
	public GameObject[] clone;
	public GameObject turretBaseObj;


	void Awake()
	{
		thisTransform = transform;
		clone = new GameObject[ammo]; 					// This needs to run before the projectiles are instantiated
		InstantiateProjectiles();
	}

	// Use this for initialization
	void Start ()
	{
		angularMove = GetComponent<AngularMovement>();
		energyBar = GetComponentInChildren<EnergyBar>();
	}

	// Update is called once per frame
	void FixedUpdate ()
	{
		angularMove.PointAtCursor();

		if(energyBar.Energy > 0)
		{
			if(Input.touchCount > 0)
			{   
				if(IsInputLocked()){}
				
				else
				{
					SetNextBullet();
					ActivateProjectiles();
					energyBar.UseEnergy();
					Lock();
				}
			}
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.tag == "Bullet")
			col.transform.parent = thisTransform;

		if(col.tag == "Asteroid")
			Application.LoadLevel("End");
	}

	void OnTriggerExit2D(Collider2D col)
	{
		if(col.tag == "Bullet")
			col.transform.parent = null;
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
	}

	private void ActivateProjectiles()
	{
		if(clone[GetNextBullet()].activeSelf == false)
		{
			bulletRef = clone[GetNextBullet()].GetComponent<Bullet>();
			
			clone[GetNextBullet()].SetActive(true);
			bulletRef.GetComponent<Bullet>().Activate();
			clone[GetNextBullet()].transform.position = thisTransform.position;
			clone[GetNextBullet()].transform.rotation = thisTransform.rotation;
			clone[GetNextBullet()].rigidbody2D.AddForce(bulletRef.transform.up * bulletRef.projectileSpeed);
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
}

