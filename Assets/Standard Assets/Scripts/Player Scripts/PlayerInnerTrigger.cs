using UnityEngine;
using System.Collections;

public class PlayerInnerTrigger : MonoBehaviour
{
	public void OnTriggerEnter(Collider col)
	{
		CollisionManager.Instance.PlayerInnerTriggerEnter(col);
	}
}

