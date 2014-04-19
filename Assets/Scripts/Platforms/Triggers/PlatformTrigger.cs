using UnityEngine;
using System.Collections;

public class PlatformTrigger : MonoBehaviour
{
	void OnTriggerEnter(Collider col)
	{
		if(col.tag == "Player")
		{
			col.transform.parent = this.transform;
		}
	}
	
	void OnTriggerExit(Collider col)
	{
		if(col.tag == "Player")
		{
			col.transform.parent = null;
		}
	}
}

