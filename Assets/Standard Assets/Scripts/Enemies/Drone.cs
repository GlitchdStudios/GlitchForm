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
		
		if(EnemyManager.Instance.target != null) 
			playerTrigger = EnemyManager.Instance.target.GetComponentInChildren<PlayerTrigger>();
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
		enemyState.enemyMoving.enemyMovingSpeed = speed;
		enemyState.enemyMoving.playerTriggerRef = playerTrigger;
		
	}
	
	// Update is called once per frame
	void Update ()
	{		
		enemyState.ActivateState();
		
		droneTrigger.SetTriggerHeight(transform.position.y);
		
		CheckDroneStatus();
		
		//Debug.Log("Height " + height);
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
		
		if(baseHealth <= 0) //dead
			enemyState.CurDroneState = enemyState.dead;
			enemyState.dead.DeadGameObject = gameObject;
			enemyState.ActivateState();
	}
	
	public int Angle { get {return range; } set { range = value; } }
}


