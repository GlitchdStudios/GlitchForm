using UnityEngine;
using System.Collections;

public class Chained : AbstractState
{
	private float deviation;

	public Transform location;
	public float speedChained;
	public float radius;
	public Vector3 dir;

	public void Setup(Transform m_location)
	{
		//otherCollider = m_otherCollider;
		location = m_location;
		radius = 1.0f;

		if(EnemyManager.Instance.target != null) 
			deviation = Random.Range(0.5f, (location.collider2D as CircleCollider2D).radius - 2f);
	}

	public void TargetBullet(float x, float y)
	{
		if(EnemyManager.Instance.target != null)
		{	
			StateManager.Instance.targetPos = new Vector2(x, y);
			//transform.position = new Vector2(transform.position.x,transform.position.y);
		}	
	}
	
	public void MoveDrone (Vector2 start, Vector2 target, float maxDistDelta) 
	{	
		dir = (transform.position - StateManager.Instance.targetPos).normalized * (radius + deviation) + StateManager.Instance.targetPos; 
		transform.position = Vector2.MoveTowards(start, dir, maxDistDelta);
		transform.RotateAround(target, Vector3.back, 3);
    }
	
	public override void ResolveState() 
	{
		TargetBullet(location.position.x, location.position.y);
		MoveDrone(transform.position, StateManager.Instance.targetPos, speedChained * Time.deltaTime);
	}
}

