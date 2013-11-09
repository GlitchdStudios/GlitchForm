using UnityEngine;
using System.Collections;

public class PlayerMoving : PlayerState
{
	public PlayerMovement playerMovement;
	
	void Awake()
	{
		playerMovement = GetComponent<PlayerMovement>();
	}
	
	public override void ResolveState()
	{
		if(StateManager.Instance.player != null)
		{
			playerMovement.Movement();
		}
	}
}

