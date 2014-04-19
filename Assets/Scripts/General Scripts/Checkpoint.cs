using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour
{
	void OnTriggerEnter(Collider col)
	{
		if(col.tag == "Player")
		{
			col.GetComponent<Player>().initPos = this.transform.position;
		}
	}
}

