using UnityEngine;
using System.Collections;

public abstract class AbstractState : Singleton<AbstractState>
{
	public abstract void ResolveState();
}

