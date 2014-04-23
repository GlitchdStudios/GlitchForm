using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour
{	
	public ChromaState _chromaState;

	void OnTriggerEnter(Collider col)
	{
		if(col.tag == "Player")
		{
			col.GetComponent<Player>().initPos = this.transform.position;
			InitPlatformPosition();
			Toolbox.initChromaState = _chromaState;
		}
	}

	private void InitPlatformPosition()
	{
		foreach(Platform platform in Toolbox.platforms)
		{
			platform.GetComponent<Platform>().initPlatformPos = platform.transform.position;
		}
	}
}

