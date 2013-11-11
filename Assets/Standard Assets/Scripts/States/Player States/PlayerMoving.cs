using UnityEngine;
using System.Collections;

public class PlayerMoving : AbstractState
{
	public PlayerMovement playerMovement;
	
	void Start()
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

