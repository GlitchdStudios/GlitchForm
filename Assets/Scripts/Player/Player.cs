using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	public Vector3 initPos;

	// Use this for initialization
	void Start ()
	{
		initPos = Toolbox.playerTransform.position;
	}
}

