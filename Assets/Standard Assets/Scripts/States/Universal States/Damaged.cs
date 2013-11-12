using UnityEngine;
using System.Collections;

public class Damaged : AbstractState
{
	private BaseEntity attacker;
	private BaseEntity defender;
	
	public override void ResolveState()
	{
		defender.Health -= attacker.Damage;
	}
	
	public BaseEntity Attacker {set{attacker = value;} get{return attacker;}}
	public BaseEntity Defender {set{defender = value;} get{return defender;}}
}

