using UnityEngine;
using System.Collections;

public class EnergyBar : MonoBehaviour
{
	public Sprite[] sprites;
	public float time;

	private int energy;
	private int energyRegen;
	private SpriteRenderer spriteRenderer;
	private int frames;

	// Use this for initialization
	void Start ()
	{
		spriteRenderer = renderer as SpriteRenderer;
		energy = 19;
		energyRegen = 1;

		StartCoroutine(RegenEnergy());
	}

	public void ChangeAniFrame()
	{
		frames = energy;
		spriteRenderer.sprite = sprites[frames];
	}

	public void UseEnergy()
	{
		if(energy > 0)
		{
			energy--;
			ChangeAniFrame();
		}
	}

	public IEnumerator RegenEnergy()
	{
		while(true)
		{
			yield return new WaitForSeconds(time);

			if(energy < 19)
			{
				energy += energyRegen;
				ChangeAniFrame();
				//Debug.Log(energy);
			}

			else
			{
				StartCoroutine(RegenEnergy());
				break;
			}
		}
	}

	public int Energy {get{ return energy;} }
}

