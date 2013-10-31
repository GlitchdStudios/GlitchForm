using UnityEngine;
using System.Collections;

public abstract class AbstractState : MonoBehaviour
{
	public void ChangeState(AbstractState absState)
	{
		absState.ResolveState();
	}
	
	public abstract void ResolveState();
}

