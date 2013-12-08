using UnityEngine;
using System.Collections;

public class DroneTrigger : MonoBehaviour
{
	public void OnTriggerEnter(Collider col)
	{
		CollisionManager.Instance.DroneTriggerEnter(col, transform);
	}
}


