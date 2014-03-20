using UnityEngine;
using System.Collections;

public class EnergyBar : MonoBehaviour
{
	public Sprite[] sprites;
	public float time;

	private int energy;
	private int[] minEnergy;
	private int energyRegen;
	private SpriteRenderer spriteRenderer;
	private int frames;

	// Use this for initialization
	void Start ()
	{
		spriteRenderer = renderer as SpriteRenderer;
		energy = 19;
		minEnergy = new int[2];
		minEnergy[(int)BulletType.BULLET] = 0;
		minEnergy[(int)BulletType.SUPER_BULLET] = 4;  // Condition checks if energy is > 4
		energyRegen = 1;

		StartCoroutine(RegenEnergy());
	}

	public void ChangeAniFrame()
	{
		frames = energy;
		spriteRenderer.sprite = sprites[frames];
	}

	public void UseEnergy(BulletType bulletType)
	{
		switch(bulletType)
		{
			case BulletType.BULLET:
				if(energy > minEnergy[(int)bulletType])
					energy--;
			break;

			case BulletType.SUPER_BULLET:
				if(energy > minEnergy[(int)bulletType])
					energy -= 5;
			break;
		}
		ChangeAniFrame();
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

	public int MinEnergy(BulletType bulletType)
	{ 
		return minEnergy[(int)bulletType];	
	}

	public int Energy { get{ return energy;} }
}

