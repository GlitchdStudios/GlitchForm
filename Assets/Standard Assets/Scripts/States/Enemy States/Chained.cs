using UnityEngine;
using System.Collections;

public class Chained : AbstractState
{
	public Collider otherCollider;
	public Transform location;
	
	public void Setup(Collider m_otherCollider, Transform m_location)
	{
		otherCollider = m_otherCollider;
		location = m_location;
	}
	
	public override void ResolveState() 
	{
		otherCollider.transform.parent.GetComponent<Drone>().TargetBullet(location.position.x, location.position.z, false);
	}
}

