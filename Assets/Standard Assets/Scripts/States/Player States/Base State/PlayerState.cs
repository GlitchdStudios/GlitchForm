using UnityEngine;
using System.Collections;

public class PlayerState : AbstractState
{
	public PlayerMoving playerMoving;
	
	void Start()
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
	
	public AbstractState CurPlayerState { get { return absState;} set { absState = value; }}
}

