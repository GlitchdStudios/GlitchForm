using UnityEngine;
using System.Collections;

public class AbstractState : Singleton<AbstractState>
{
	protected AbstractState absState;

	private AbstractState absStatus;

	public virtual void ResolveState(){}

	//For Movement/Direction States
	public virtual void ResolveState(BaseEntity baseEntity){}

	public AbstractState CurGameObjStatus {get { return absStatus;} set { absStatus = value; }}
}

