using UnityEngine;
using System.Collections;

public class Drone : BaseEntity
{
	private DroneTrigger droneTrigger;
	private PlayerTrigger playerTrigger;
	private int range;
	
	public float height;
	public float speed;
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
		speed = 5f;
		
		enemyState = gameObject.GetComponent<EnemyState>();
		
		Angle = Random.Range(-20,20);
		
		enemyState.CurDroneState = enemyState.enemyMoving;	
	}
	
	// Update is called once per frame
	void Update ()
	{	
		if(enemyState.CurDroneState == enemyState.enemyMoving)
		{
			enemyState.enemyMoving.enemyMovingSpeed = speed;
			enemyState.enemyMoving.playerTriggerRef = playerTrigger;
			enemyState.ActivateState();
		}
		
		droneTrigger.SetTriggerHeight(transform.position.y);
		
		CheckDroneStatus();
		
		Debug.Log("Current Drone State: " + enemyState.CurDroneState);
	}
	
	public IEnumerator ResetSpeed()
	{
		yield return new WaitForSeconds(2.0f);
		if(speed < 0)
		{
			speed = 5f;
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


