using UnityEngine;
using System.Collections;

public class EnemyState : AbstractState
{
	public void ActivateState()
	{
		if(CurDroneState != null)
		{
			CurDroneState.ResolveState();
		}
	}
	
	public AbstractState CurDroneState { get { return absState;} set { absState = value; }}
}

