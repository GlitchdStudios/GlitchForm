using UnityEngine;
using System.Collections;

public class Orbiting : AbstractState
{
	private EnemyMoving enemyMoving;
	
	public Collider otherCollider;
	public Transform trigger;
	
	void Start()
	{
		enemyMoving = GetComponent<EnemyMoving>();
	}
	
	public void SetOrbit(Collider m_otherCollider, Transform m_trigger)
	{
		otherCollider = m_otherCollider;
		trigger = m_trigger;
	}
	
	public override void ResolveState()
	{
		if(otherCollider != null)
			otherCollider.transform.parent.RotateAround(trigger.position, Vector3.up, otherCollider.transform.parent.GetComponent<Drone>().Angle * Time.deltaTime);
	}
}