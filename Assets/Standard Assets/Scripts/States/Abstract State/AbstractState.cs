using UnityEngine;
using System.Collections;

public class AbstractState : Singleton<AbstractState>
{
	protected AbstractState absState;
	protected AbstractState absStatus;

	public virtual void ResolveState(){}
	
	public AbstractState CurGameObjStatus {get { return absStatus;} set { absStatus = value; }}
}

