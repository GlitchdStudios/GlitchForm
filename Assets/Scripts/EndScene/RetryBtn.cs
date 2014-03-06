using UnityEngine;
using System.Collections;

public class RetryBtn : MonoBehaviour
{
	private string retryText;
	private Rect retryRect;
	private Vector3 pixelPos;

	public GUIStyle style;

	void Start()
	{
		pixelPos = Camera.main.WorldToScreenPoint(transform.position);
		pixelPos.x -= GUIManager.Instance.width/2;
		pixelPos.y -= GUIManager.Instance.height/2;
		retryRect = new Rect(pixelPos.x, pixelPos.y, GUIManager.Instance.width,GUIManager.Instance.height);
		retryText = "Retry";
	}

	void OnGUI()
	{
		if(GUI.Button(retryRect, retryText, style))
		{
			Debug.Log("blah11111");
		}
	}
}

