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
			deviationX = Random.Range(-(playerTriggerRef.collider as SphereCollider).radius, (playerTriggerRef.collider as SphereCollider).radius);
			deviationY = Random.Range(-(playerTriggerRef.collider as SphereCollider).radius, (playerTriggerRef.collider as SphereCollider).radius);
	}
	
	public void TargetPlayer()
	{
		if(EnemyManager.Instance.target != null)
		{
			StateManager.Instance.targetPos = new Vector3(EnemyManager.Instance.target.transform.position.x + deviationX, EnemyManager.Instance.target.transform.position.y + deviationY);
			transform.position = new Vector3(transform.position.x, transform.position.y);
		}
	}
	
	public void MoveDrone (Vector3 start, Vector3 target, float maxDistDelta) 
	{	
		transform.position = Vector3.MoveTowards(start, target, maxDistDelta);	
	}

	public override void ResolveState()
	{
		TargetPlayer();
		MoveDrone(transform.position, StateManager.Instance.targetPos, speedMoving * Time.deltaTime);
	}
}
