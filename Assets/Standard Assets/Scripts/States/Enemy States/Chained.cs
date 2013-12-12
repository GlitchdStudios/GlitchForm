using UnityEngine;
using System.Collections;

public class Chained : AbstractState
{
	public Collider otherCollider;
	public Transform location;
	public float speedChained;

	public void Setup(Collider m_otherCollider, Transform m_location)
	{
		otherCollider = m_otherCollider;
		location = m_location;
	}
	
	public void TargetBullet(float x, float y)
	{
		if(EnemyManager.Instance.target != null)
		{	
			StateManager.Instance.targetPos = new Vector2(x, y);
			transform.position = new Vector2(transform.position.x,transform.position.y);
		}	
	}
	
	public void MoveDrone (Vector2 start, Vector2 target, float maxDistDelta) 
	{	
		Vector2 dir = target - start;
		dir = dir.normalized;
		rigidbody2D.AddForce(10 * dir);
    }
	
	public override void ResolveState() 
	{
		TargetBullet(location.position.x, location.position.y);
		MoveDrone(transform.position, StateManager.Instance.targetPos, speedChained * Time.deltaTime);
	}
}

