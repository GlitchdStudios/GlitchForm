using UnityEngine;
using System.Collections;

public class ChromaControls : MonoBehaviour
{
	public enum ChromaState { BLUE = 0, RED }

	private GameObject[] chroma;
	public ChromaState chromaState;

	void Start()
	{
		chroma = GameObject.FindGameObjectsWithTag("Chroma");
	}

	// Update is called once per frame
	void Update ()
	{
		if(Input.GetKeyDown("1"))
		{
			chromaState = ChromaState.BLUE;
			chroma[(int)ChromaState.BLUE].SetActive(true);
		}

		if(Input.GetKeyDown("2"))
		{
			chromaState = ChromaState.RED;
			chroma[(int)ChromaState.RED].SetActive(true);
		}

		for(int i = 0; i < chroma.Length; i++)
		{
			if((int)chromaState != i)
			{
				chroma[i].SetActive(false);
			}
		}
	}
}

