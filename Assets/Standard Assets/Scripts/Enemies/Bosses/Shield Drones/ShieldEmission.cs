using UnityEngine;
using System.Collections;

public class ShieldEmission : MonoBehaviour
{
	public GameObject targetObj;
	public GameObject shieldNode;

	private LineRenderer lineRef;
	private Transform thisTransform;
	private int points;
	private float t;

	// Use this for initialization
	void Start ()
	{
		points = 20;
		lineRef = GetComponent<LineRenderer>();
		lineRef.SetVertexCount(points);
		thisTransform = transform;
	}

	// Update is called once per frame
	void Update ()
	{
		for(int i = 0; i < points; i++)
		{
			t = i/(float)(points-1);
			Vector2 arc = Mathf.Pow(1-t,2)*thisTransform.position + 2*t*(1-t)*shieldNode.transform.position + Mathf.Pow(t,2)*targetObj.transform.position;
			
			arc.x += Random.Range(-0.1f,0.1f);
			arc.y += Random.Range(-0.1f,0.1f);
			
			lineRef.SetPosition(i, arc);
		}
	}
}

