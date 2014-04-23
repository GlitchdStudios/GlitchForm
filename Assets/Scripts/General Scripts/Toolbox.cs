using UnityEngine;
using System.Collections;

public enum ChromaState { BLUE = 0, RED }

public class Toolbox : MonoBehaviour
{
	public GameObject playerObj;
	public GameObject cameraObj;
	public GameObject followObj;
	public GameObject dataSphereObj;
	public static GameObject dataSlotObj;
	public static Collider dataSlotCenter;
	public static Transform followTrans;
	public static Transform playerTransform;
	public static Transform mainCameraTransform;
	public static CharacterControls characterControls;
	public static DataSphere dataSphereScr;
	public static Player playerScr;
	public static float generalGravityForce;
	public static ChromaState chromaState;
	public static ChromaState initChromaState;
	public static GameObject[] chroma;
	public static bool isControlable = true;
	public static Platform[] platforms;

	void Awake () 
	{
		characterControls = playerObj.GetComponent<CharacterControls>();
		playerScr = playerObj.GetComponent<Player>();
		playerTransform = playerObj.transform;
		mainCameraTransform = cameraObj.transform;
		followTrans = followObj.transform;
		generalGravityForce = 9.81f;
		platforms =	FindObjectsOfType(typeof(Platform)) as Platform[];
	}
}
