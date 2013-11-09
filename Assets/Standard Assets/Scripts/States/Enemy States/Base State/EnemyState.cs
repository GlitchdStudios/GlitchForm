using UnityEngine;
using System.Collections;

public class EnemyState : AbstractState
{
	public Orbiting orbiting;
	
	void Awake()
	{
		orbiting = gameObject.GetComponent<Orbiting>();
	}
	
	public void ActivateState()
	{
		if(CurDroneState != null)
		{
			CurDroneState.ResolveState();
		}
	}
	
	public AbstractState CurDroneState { get { return absState;} set { absState = value; }}
}

