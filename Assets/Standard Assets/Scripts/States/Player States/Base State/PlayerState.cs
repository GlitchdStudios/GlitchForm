using UnityEngine;
using System.Collections;

public class PlayerState : AbstractState
{
	public Player player;
	
	void Start()
	{
		player = gameObject.GetComponent<Player>();
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

