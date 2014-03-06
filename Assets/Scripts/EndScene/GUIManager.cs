using UnityEngine;
using System.Collections;

public class GUIManager : Singleton<GUIManager>
{
	public int width;
	public int height;

	void Start()
	{
		width = 100;
		height = 50;
	}

	public void GetTime()
	{
		guiText.text = EventManager.Instance.gameTime.ToString();
	}
}

