using UnityEngine;
using System.Collections;

public class EnemyState : AbstractState
{
	private AbstractState movementDirState;

	public EnemyMoving enemyMoving;
	public Forward forward;
	public Backward backward;
	public Stopped stopped;

	public Orbiting orbiting;
	public Chained chained;
	public Dead dead;
	
	void Awake()
	{
		enemyMoving = gameObject.GetComponent<EnemyMoving>();
		forward = gameObject.GetComponent<Forward>();
		backward = gameObject.GetComponent<Backward>();
		stopped = gameObject.GetComponent<Stopped>();

		orbiting = gameObject.GetComponent<Orbiting>();
		chained = gameObject.GetComponent<Chained>();
		dead = gameObject.GetComponent<Dead>();
	}

	public void ActivateState()
	{
		if(CurDroneState != null)
		{
			CurDroneState.ResolveState();
		}
	}
	
	public void ActivateStatus()
	{
		if(CurGameObjStatus != null)
		{
			CurGameObjStatus.ResolveState();
		}
	}

	public void ActivateMovementDirState(BaseEntity baseEntity)
	{
		if(CurMovementDirState != null)
		{
			CurMovementDirState.ResolveState(baseEntity);
		}
	}

	public AbstractState CurDroneState 		 { get { return absState;} set { absState = value; }}
}

