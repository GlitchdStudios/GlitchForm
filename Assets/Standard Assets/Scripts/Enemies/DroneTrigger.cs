using UnityEngine;
using System.Collections;

public class DroneTrigger : MonoBehaviour
{
	public void OnTriggerEnter(Collider col)
	{
		CollisionManager.Instance.DroneTriggerEnter(col, transform);
	}
	
	public void SetTriggerHeight(float height)
	{
		height *= -1;
		
		transform.localPosition = new Vector3(0f, height, 0f);
	}
}


