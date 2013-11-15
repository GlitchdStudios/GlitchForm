using UnityEngine;
using System.Collections;

public class EnemyMoving : AbstractState
{
	private float deviationX;
	private float deviationZ;
	
	public float height;
	public float enemyMovingSpeed;
	public PlayerTrigger playerTriggerRef;

	void Start()
	{
		if(EnemyManager.Instance.target != null) 
			playerTriggerRef = EnemyManager.Instance.target.GetComponentInChildren<PlayerTrigger>();
		
		if(EnemyManager.Instance.target != null) 
			deviationX = Random.Range(-(playerTriggerRef.collider as SphereCollider).radius, (playerTriggerRef.collider as SphereCollider).radius);
			deviationZ = Random.Range(-(playerTriggerRef.collider as SphereCollider).radius, (playerTriggerRef.collider as SphereCollider).radius);
	}
	
	public void TargetPlayer()
	{
		if(EnemyManager.Instance.target != null)
		{
			StateManager.Instance.targetPos = new Vector3(EnemyManager.Instance.target.transform.position.x + deviationX, height, EnemyManager.Instance.target.transform.position.z + deviationZ);
			transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y,height, height),transform.position.z);
		}
	}
	
	public void MoveDrone (Vector3 start, Vector3 target, float maxDistDelta) 
	{	
		transform.position = Vector3.MoveTowards(start, target, maxDistDelta);	
    }
	
 	public override void ResolveState()
	{
		TargetPlayer();
		MoveDrone(transform.position, StateManager.Instance.targetPos, enemyMovingSpeed * Time.deltaTime);
	}
}

