using UnityEngine;
using System.Collections;

public class Backward : AbstractState
{
	private float m_speed;

	void Start()
	{
		m_speed = -200f;
	}

	public override void ResolveState(BaseEntity baseEntity)
	{
		ChangeSpeed(baseEntity);
	}

	public void ChangeSpeed(BaseEntity baseEntity)
	{
		baseEntity.baseSpeed = m_speed;
	}
}