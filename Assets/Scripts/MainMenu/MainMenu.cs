using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour
{
	// Update is called once per frame
	void Update ()
	{
		if(Input.touchCount > 0)
		{
			Application.LoadLevel("Main");
		}
	}
}

