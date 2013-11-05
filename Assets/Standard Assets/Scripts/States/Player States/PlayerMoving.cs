using UnityEngine;
using System.Collections;

public class PlayerMoving : PlayerState
{
	public override void ResolveState()
	{
		player.playerMovement.Movement();
	}
}

