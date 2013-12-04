using UnityEngine;
using System.Collections;

public class WorldtoScreen : MonoBehaviour
{
	public float top;
	public float bottom;
	public float left;
	public float right;

	public void Awake()
	{
		var topRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));
		var bottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
		top = topRight.x; // topRight.z if your camera is looking in -y direction
		right = topRight.z;
		bottom = bottomLeft.x; // bootmLeft.z, if camera in -y direction
		left = bottomLeft.z;
	}
}

