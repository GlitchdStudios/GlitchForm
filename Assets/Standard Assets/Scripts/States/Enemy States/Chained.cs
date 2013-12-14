using UnityEngine;
using System.Collections;

public class Chained : AbstractState
{

	private float deviationX;
	private float deviationY;

	public Transform location;
	public float speedChained;
	public float radius;
	public Vector3 dir;

	public void Setup(Transform m_location)
	{
		//otherCollider = m_otherCollider;
		location = m_location;
		radius = 2.0f;

		if(EnemyManager.Instance.target != null) 
			deviationX = Random.Range(-(location.collider as SphereCollider).radius, (location.collider as SphereCollider).radius);
			deviationY = Random.Range(-(location.collider as SphereCollider).radius, (location.collider as SphereCollider).radius);
	}

	public void TargetBullet(float x, float y)
	{
		if(EnemyManager.Instance.target != null)
		{	
			StateManager.Instance.targetPos = new Vector2(x + deviationX, y + deviationY);
			//transform.position = new Vector2(transform.position.x,transform.position.y);
		}	
	}
	
	public void MoveDrone (Vector2 start, Vector2 target, float maxDistDelta) 
	{	
		//dir = (transform.position - StateManager.Instance.targetPos).normalized * radius + StateManager.Instance.targetPos; 
		transform.RotateAround(target, Vector3.back, 80);

		transform.position = Vector2.MoveTowards(start, target, maxDistDelta);
    }
	
	public override void ResolveState() 
	{
		TargetBullet(location.position.x, location.position.y);
		MoveDrone(transform.position, StateManager.Instance.targetPos, speedChained * Time.deltaTime);
	}
}

