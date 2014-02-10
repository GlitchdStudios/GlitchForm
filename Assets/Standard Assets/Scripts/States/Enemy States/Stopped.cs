using UnityEngine;
using System.Collections;

public class Stopped : AbstractState
{
	private float m_speed;
	private float time;
	private float timer;

	// Use this for initialization
	void Start ()
	{
		m_speed = 0f;
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

