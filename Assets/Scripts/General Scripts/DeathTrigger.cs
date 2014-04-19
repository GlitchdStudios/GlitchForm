using UnityEngine;
using System.Collections;

public class DeathTrigger : MonoBehaviour
{
	private Platform[] platforms;
	private DataSphere[] dataSpheres;

	void Start()
	{
		platforms =	FindObjectsOfType(typeof(Platform)) as Platform[];
		dataSpheres = FindObjectsOfType(typeof(DataSphere)) as DataSphere[];
	}

	void OnTriggerExit(Collider col)
	{
		if(col.tag == "Player")
		{
			Toolbox.playerTransform.position = Toolbox.playerScr.initPos;
			InitPlatformsOnDeath();
			Toolbox.playerTransform.rigidbody.Sleep();
			Toolbox.characterControls.Gravity = Vector3.down * Toolbox.generalGravityForce;
		}

		if(col.tag == "DataSphere")
		{
			InitDataSpheresOnDeath();
		}
	}


	private void InitDataSpheresOnDeath()
	{
		foreach(DataSphere dataSphere in dataSpheres)
		{
			dataSphere.rigidbody.Sleep();
			dataSphere.transform.position = dataSphere.initPos;
		}
	}
	private void InitPlatformsOnDeath()
	{
		foreach(Platform platform in platforms)
		{
			platform.GetComponent<Platform>().InitPlatform();
		}
	}
}

