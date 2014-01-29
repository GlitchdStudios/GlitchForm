using UnityEngine;
using System.Collections;
using System;

public class DroneIndicator : MonoBehaviour
{
	public Sprite[] sprites;

	private SpriteRenderer spriteRenderer;
	private int frames;

	// Use this for initialization
	void Start ()
	{
		spriteRenderer = renderer as SpriteRenderer;
	}

	public void ChangeAniFrame()
	{
		frames = EnemyManager.Instance.CurNumOfDrones;
		spriteRenderer.sprite = sprites[frames];
	}
}

