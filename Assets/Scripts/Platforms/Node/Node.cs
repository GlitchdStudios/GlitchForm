using UnityEngine;
using System.Collections;

public class Node : MonoBehaviour
{
	public void MoveToNode(Transform platform, Transform node, float speed)
	{
		platform.localPosition = Vector3.MoveTowards(platform.localPosition, node.localPosition, speed);
	}

	public void RotateToNode(Transform platform, Transform node, float speed)
	{
		platform.rotation = Quaternion.RotateTowards(platform.rotation, node.rotation, speed * Time.deltaTime);
	}
}

