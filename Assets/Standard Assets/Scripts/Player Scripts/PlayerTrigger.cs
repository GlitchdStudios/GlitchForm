using UnityEngine;
using System.Collections;

public class PlayerTrigger : MonoBehaviour
{
	public void OnTriggerEnter(Collider col)
	{
		CollisionManager.Instance.PlayerTriggerEnter(col, transform);
	}
	
	public void OnTriggerStay(Collider col)
	{
		CollisionManager.Instance.PlayerTriggerStay(col, transform);
	}
	
	public void OnTriggerExit(Collider col)
	{
		CollisionManager.Instance.PlayerTriggerExit(col);
	}
	
}

