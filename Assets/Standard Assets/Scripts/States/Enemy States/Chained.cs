using UnityEngine;
using System.Collections;

public class Chained : AbstractState
{
	public Collider otherCollider;
	public Transform location;
	public float speedChained;
	public Transform center;
	public Vector3 desiredPosition;
	public float radius = 2.0f;
	public float rotationSpeed = 80.0f;

	void Start()
	{
		center = transform;
		transform.position = (transform.position - center.position).normalized * radius + center.position;
		radius = 2.0f;
	}
	
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
		transform.RotateAround (center.position, Vector3.back, rotationSpeed * Time.deltaTime);
		desiredPosition = (transform.position - center.position).normalized * radius + center.position;
        transform.position = Vector2.MoveTowards(transform.position, desiredPosition, Time.deltaTime * maxDistDelta);
    }
	
	public override void ResolveState() 
	{
		TargetBullet(location.position.x, location.position.y);
		MoveDrone(transform.position, StateManager.Instance.targetPos, speedChained * Time.deltaTime);
	}
}

