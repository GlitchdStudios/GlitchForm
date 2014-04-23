using UnityEngine;
using System.Collections;

public class ParentTrigger : MonoBehaviour
{
	void OnTriggerStay(Collider col)
	{
		Debug.Log(col.tag);
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

