using UnityEngine;
using System.Collections;

public class EndScene : MonoBehaviour
{	
	private Vector3 pixelPos;
	private int width;
	private int height;

	public Font timerFont;

	void Start()
	{
		width = 200;
		height = 100;

		GUIManager.Instance.GetTime();
	}
	
//
//	void OnGUI()
//	{
//		pixelPos = Camera.main.WorldToScreenPoint(transform.position);
//		pixelPos.x -= width/2;
//		pixelPos.y -= height/2;
//
//		GUIStyle centeredStyle = GUI.skin.GetStyle("Label");
//		centeredStyle.alignment = TextAnchor.UpperCenter;
//		centeredStyle.font = timerFont; 
//		centeredStyle.normal.textColor = Color.black;
//
//		GUI.Label(new Rect(pixelPos.x, pixelPos.y, width, height), GUIManager.Instance.GetTime());
//	}
}

