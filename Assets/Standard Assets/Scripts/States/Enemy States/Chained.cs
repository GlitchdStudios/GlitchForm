using UnityEngine;
using System.Collections;

public class Chained : AbstractState
{
	public float height;
	public Collider otherCollider;
	public Transform location;
	
	public void Setup(Collider m_otherCollider, Transform m_location)
	{
		otherCollider = m_otherCollider;
		location = m_location;
	}
	
	public void TargetBullet(float x, float z)
	{
		if(EnemyManager.Instance.target != null)
		{	
			StateManager.Instance.targetPos = new Vector3(x, height, z);
			transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, height, height),transform.position.z);
		}
		
	}
	
	public void MoveDrone (Vector3 start, Vector3 target, float maxDistDelta) 
	{	
		transform.position = Vector3.MoveTowards(start, target, maxDistDelta);	
    }
	
	public override void ResolveState() 
	{
		TargetBullet(location.position.x, location.position.z);
	}
}

