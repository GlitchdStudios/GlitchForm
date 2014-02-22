using UnityEngine;
using System.Collections;

public class EnergyBar : MonoBehaviour
{
	public Sprite[] sprites;

	private int energy;
	private int energyRegen;
	private SpriteRenderer spriteRenderer;
	private int frames;

	// Use this for initialization
	void Start ()
	{
		spriteRenderer = renderer as SpriteRenderer;
		energy = 18;
		energyRegen = 1;
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
}

