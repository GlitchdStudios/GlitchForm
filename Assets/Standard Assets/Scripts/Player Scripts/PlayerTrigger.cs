using UnityEngine;
using System.Collections;

public class PlayerTrigger : MonoBehaviour
{
	public void OnTriggerEnter2D(Collider2D col)
	{
		CollisionManager.Instance.PlayerTriggerEnter(col, transform);
		Debug.Log("PlayerTriggerEnter");
	}
	
	public void OnTriggerStay2D(Collider2D col)
	{
		CollisionManager.Instance.PlayerTriggerStay(col, transform);

	}
	
	public void OnTriggerExit2D(Collider2D col)
	{
		CollisionManager.Instance.PlayerTriggerExit(col);
	}
	
}

