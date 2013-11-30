using UnityEngine;
using System.Collections;

public class PlayerState : AbstractState
{
	public PlayerMoving playerMoving;
	
	void Awake()
	{
		playerMoving = gameObject.GetComponent<PlayerMoving>();
	}
	
	public void ActivateState()
	{
		if(CurPlayerState != null)
		{
			CurPlayerState.ResolveState();
		}
	}
	
	public void ActivateStatus()
	{
		if(CurPlayerState != null)
		{
			CurGameObjStatus.ResolveState();
		}
	}

	public AbstractState CurPlayerState { get { return absState;} set { absState = value; }}
}

