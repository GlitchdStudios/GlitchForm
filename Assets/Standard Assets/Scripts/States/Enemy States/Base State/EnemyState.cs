using UnityEngine;
using System.Collections;

public class EnemyState : AbstractState
{
	public EnemyMoving enemyMoving;
	public Orbiting orbiting;
	public Chained chained;
	public Dead dead;
	
	void Awake()
	{
		enemyMoving = gameObject.GetComponent<EnemyMoving>();
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
	
	public AbstractState CurDroneState { get { return absState;} set { absState = value; }}
}

