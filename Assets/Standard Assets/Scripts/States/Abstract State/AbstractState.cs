using UnityEngine;
using System.Collections;

public class AbstractState : Singleton<AbstractState>
{
	protected AbstractState absState;

	private AbstractState absStatus;
	private AbstractState absMovementStatus;

	public virtual void ResolveState(){}

	//For Movement/Direction States
	public virtual void ResolveState(BaseEntity baseEntity){}

	public AbstractState CurGameObjStatus {get { return absStatus;} set { absStatus = value; }}
	public AbstractState CurMovementDirState { get { return absMovementStatus; } set {absMovementStatus = value;}}
}

