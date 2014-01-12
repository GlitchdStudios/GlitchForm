using UnityEngine;
using System.Collections;

public class Orbiting : AbstractState
{
	public Collider2D otherCollider;
	public Transform trigger;
	
	public void SetOrbit(Collider2D m_otherCollider, Transform m_trigger)
	{
		otherCollider = m_otherCollider;
		trigger = m_trigger;
	}
	
	public override void ResolveState()
	{
		otherCollider.transform.parent.RotateAround(trigger.position, Vector3.back, otherCollider.transform.parent.GetComponent<Drone>().Angle * Time.deltaTime);
	}
}