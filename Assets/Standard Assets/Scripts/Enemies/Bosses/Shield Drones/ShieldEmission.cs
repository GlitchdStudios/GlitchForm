using UnityEngine;
using System.Collections;

public class ShieldEmission : MonoBehaviour
{
	public GameObject targetObj;

	private LineRenderer lineRef;
	private Transform thisTransform;
	private int points;

	// Use this for initialization
	void Start ()
	{
		lineRef = GetComponent<LineRenderer>();
		thisTransform = transform;
		points = 4;
	}

	// Update is called once per frame
	void Update ()
	{
		lineRef.SetPosition(0, thisTransform.position);

		for(int i = 1; i < points; i++)
		{
			Vector2 pos = Vector2.Lerp(thisTransform.position,targetObj.transform.position, i/4.0f);

			pos.x += Random.Range(-0.4f,0.4f);
			pos.y += Random.Range(-0.4f,0.4f);

			lineRef.SetPosition(i, pos);
		}
		
		lineRef.SetPosition(points, targetObj.transform.position);
	}
}

