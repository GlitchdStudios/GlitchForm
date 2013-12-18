using UnityEngine;
using System.Collections;

public class Drone : BaseEntity
{
	private DroneTrigger droneTrigger;
	private SpriteRenderer spriteDraw;
	private int range;
	
	public bool damagePlayer;
	
	//States
	public EnemyState enemyState;

	void Awake()
	{
		droneTrigger = gameObject.GetComponentInChildren<DroneTrigger>();	
	}
	
	// Use this for initialization
	void Start ()
	{
		baseHealth = 20;
		baseDamage = 1;
		baseSpeed = 5f;

		enemyState = gameObject.GetComponent<EnemyState>();
		
		Angle = Random.Range(-20,20);
		
		enemyState.CurDroneState = enemyState.enemyMoving;
		drawOrder -= 1;
		gameObject.renderer.sortingOrder = drawOrder;
	}
	
	// Update is called once per frame
	void Update ()
	{	
		if(enemyState.CurDroneState == enemyState.enemyMoving)
		{
			enemyState.enemyMoving.speedMoving = baseSpeed;
			enemyState.chained.speedChained = baseSpeed;
			enemyState.ActivateState();
		}

		CheckDroneStatus();
		
		//Debug.Log("Current Drone State: " + enemyState.CurDroneState);
	}

	void FixedUpdate()
	{
		if(enemyState.CurDroneState == enemyState.chained)
		{
			enemyState.ActivateState();
		}
	}
	
	public IEnumerator ResetSpeed()
	{
		yield return new WaitForSeconds(2.0f);
		if(baseSpeed < 0)
		{
			baseSpeed = 5f;
		}
	}

	private void CheckDroneStatus()
	{
		if(baseHealth <= 0)//dead
		{
			enemyState.CurGameObjStatus = enemyState.dead;
			enemyState.dead.DeadGameObject = gameObject;
			enemyState.ActivateStatus();
		}
	}
	
	public int Angle { get {return range; } set { range = value; } }
}


