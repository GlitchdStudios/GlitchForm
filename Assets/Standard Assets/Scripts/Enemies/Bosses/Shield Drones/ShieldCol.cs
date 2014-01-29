using UnityEngine;
using System.Collections;

public class ShieldCol : MonoBehaviour 
{
	public void OnTriggerEnter2D(Collider2D col)
	{
		CollisionManager.Instance.ShieldWaveTriggerEnter(col);
	}
}
