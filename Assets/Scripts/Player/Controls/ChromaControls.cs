using UnityEngine;
using System.Collections;

public class ChromaControls : MonoBehaviour
{
	void Start()
	{
		Toolbox.chroma = GameObject.FindGameObjectsWithTag("Chroma");
		Toolbox.initChromaState = ChromaState.BLUE;
	}

	// Update is called once per frame
	void Update ()
	{
		if(Input.GetKeyDown("1"))
		{
			Toolbox.chromaState = ChromaState.BLUE;
			Toolbox.chroma[(int)ChromaState.BLUE].SetActive(true);
			this.transform.parent = null;
		}

		if(Input.GetKeyDown("2"))
		{
			Toolbox.chromaState = ChromaState.RED;
			Toolbox.chroma[(int)ChromaState.RED].SetActive(true);
			this.transform.parent = null;
		}

		for(int i = 0; i < Toolbox.chroma.Length; i++)
		{
			if((int)Toolbox.chromaState != i)
			{
				if(Toolbox.chroma[i].activeSelf)
				{
					Toolbox.chroma[i].SetActive(false);
				}
			}
		}
	}
}

