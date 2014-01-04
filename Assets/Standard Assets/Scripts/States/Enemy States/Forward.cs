using UnityEngine;
using System.Collections;

public class Forward : AbstractState
{
	private float m_speed;

	// Use this for initialization
	void Start ()
	{
		m_speed = 5f;
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

