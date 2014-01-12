using UnityEngine;
using System.Collections;

public class DroneTrigger : MonoBehaviour
{
	public void OnTriggerEnter2D(Collider2D col)
	{
		CollisionManager.Instance.DroneTriggerEnter(col, transform);
	}
}


