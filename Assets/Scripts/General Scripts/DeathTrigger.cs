using UnityEngine;
using System.Collections;

public class DeathTrigger : MonoBehaviour
{
	private DataSphere[] dataSpheres;

	void Start()
	{
		dataSpheres = FindObjectsOfType(typeof(DataSphere)) as DataSphere[];
	}

	void OnTriggerExit(Collider col)
	{
		if(col.tag == "Player")
		{
			Toolbox.playerTransform.position = Toolbox.playerScr.initPos;
			Toolbox.chromaState = Toolbox.initChromaState;
			Toolbox.chroma[(int)Toolbox.chromaState].SetActive(true);

			if(!Toolbox.isControlable)
			{
				InitDataSpheresOnDeath();
			}

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
			dataSphere.SetupDataSphere(dataSphere.initChroma);
			Toolbox.isControlable = true;
		}
	}
	private void InitPlatformsOnDeath()
	{
		foreach(Platform platform in Toolbox.platforms)
		{
			platform.GetComponent<Platform>().InitPlatform();
		}
	}
}

