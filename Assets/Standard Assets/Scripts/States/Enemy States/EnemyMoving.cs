using UnityEngine;
using System.Collections;

public class EnemyMoving : AbstractState
{
	private float deviationX;
	private float deviationY;

	public PlayerTrigger playerTriggerRef;
	public float speedMoving;

	void Start()
	{
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
			StateManager.Instance.targetPos = new Vector2(EnemyManager.Instance.target.transform.position.x + deviationX, EnemyManager.Instance.target.transform.position.y + deviationY);
			//transform.position = new Vector2(transform.position.x, transform.position.y);
		}
	}
	
	public void MoveDrone (Vector2 start, Vector2 target, float maxDistDelta) 
	{	
		transform.position = Vector2.MoveTowards(start, target, maxDistDelta);	
	}

	public override void ResolveState()
	{
		TargetPlayer();
		MoveDrone(transform.position, StateManager.Instance.targetPos, speedMoving * Time.deltaTime);
	}
}
