using UnityEngine;
using System.Collections;

public class BulletState : AbstractState
{
	public ChainActive chainActive;
	
	// Use this for initialization
	void Start ()
	{
		chainActive = gameObject.GetComponent<ChainActive>();
	}
	
	public void ActivateState()
	{
		if(CurBulletState != null)
		{
			CurBulletState.ResolveState();
		}
	}
	
	public AbstractState CurBulletState { get { return absState;} set { absState = value; }}
}

