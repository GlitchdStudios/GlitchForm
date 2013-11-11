using UnityEngine;
using System.Collections;

public class AbstractState : Singleton<AbstractState>
{
	protected AbstractState absState;
	public virtual void ResolveState(){}
	
	public AbstractState CurGameObjStatus {get { return absState;} set { absState = value; }}
}

