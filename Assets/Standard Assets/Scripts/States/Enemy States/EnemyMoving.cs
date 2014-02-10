using UnityEngine;
using System.Collections;

public class EnemyMoving : AbstractState
{
	private float deviationX;
	private float deviationY;
	private Vector2 dir;
	private Drone droneRef;

	public PlayerTrigger playerTriggerRef;
	public float speedMoving;

	void Start()
	{
		droneRef = GetComponent<Drone>();

		if(EnemyManager.Instance.target != null) 
			playerTriggerRef = EnemyManager.Instance.target.GetComponentInChildren<PlayerTrigger>();
		
		if(EnemyManager.Instance.target != null) 
			deviationX = Random.Range(-(playerTriggerRef.collider2D as CircleCollider2D).radius, (playerTriggerRef.collider2D as CircleCollider2D).radius);
			deviationY = Random.Range(-(playerTriggerRef.collider2D as CircleCollider2D).radius, (playerTriggerRef.collider2D as CircleCollider2D).radius);
	}
	
	public void TargetPlayer()
	{
		if(EnemyManager.Instance.target != null)
		{
			StateManager.Instance.targetPos = new Vector2(EnemyManager.Instance.target.transform.position.x, EnemyManager.Instance.target.transform.position.y);
			//transform.position = new Vector2(transform.position.x, transform.position.y);
		}
	}
	
	public void MoveDrone (Vector2 start, Vector2 target, float maxDistDelta) 
	{	
		//transform.position = Vector2.MoveTowards(start, target, maxDistDelta);
		dir = ((Vector2)transform.position - (Vector2)target).normalized;
		if(droneRef.enemyState.CurMovementDirState = droneRef.enemyState.backward)
		{
			dir = (((Vector2)transform.position - (Vector2)target).normalized) * -1;
		}
		//transform.LookAt(dir);
		rigidbody2D.AddForce(dir * maxDistDelta);
	}

	public override void ResolveState()
	{
		TargetPlayer();
		MoveDrone(transform.position, StateManager.Instance.targetPos, speedMoving * Time.deltaTime);
	}
}
