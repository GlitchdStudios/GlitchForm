using UnityEngine;
using System.Collections;

public enum EventStage {NORMAL=0, HARD, VERY_HARD, IMPOSSIBLE, NIGHTMARE};

public class EventManager : MonoBehaviour
{
	private bool loaded;

	public GameObject asteroidSpawner;

	void Start()
	{
		SetupEvent();
	}

	// Update is called once per frame
	void FixedUpdate ()
	{
		if(Application.loadedLevel == 1)
		{
			Toolbox.gameTime = Time.timeSinceLevelLoad;
		}
	}

	private void StartEvent(EventStage eventStage)
	{
		if(Application.loadedLevel == 1)
		{
			Toolbox.curEvent = eventStage;

			switch(eventStage)
			{
				case EventStage.NORMAL:
					Toolbox.asteroidManager.InitPool(eventStage);
					StartCoroutine(Toolbox.asteroidManager.CreateAsteroids());
				break;

				case EventStage.HARD:
					Toolbox.asteroidManager.CreateMonsterRoid();
					asteroidSpawner.SetActive(false);
				break;

				case EventStage.VERY_HARD:
					Toolbox.asteroidManager.CreateMonsterRoid();
					asteroidSpawner.SetActive(false);
				break;

				case EventStage.IMPOSSIBLE:
					Toolbox.asteroidManager.CreateMonsterRoid();
					asteroidSpawner.SetActive(false);
				break;

				case EventStage.NIGHTMARE:
					Toolbox.asteroidManager.CreateMonsterRoid();
					asteroidSpawner.SetActive(false);
				break;
			}
		}
	}

	private IEnumerator SetState(int time, EventStage eventStage)
	{
		yield return new WaitForSeconds(time);
		StartEvent(eventStage);
	}

	public void SetupEvent()
	{
		StartCoroutine(SetState(0, EventStage.NORMAL));
		StartCoroutine(SetState(40, EventStage.HARD));
		StartCoroutine(SetState(80, EventStage.VERY_HARD));
		StartCoroutine(SetState(160, EventStage.IMPOSSIBLE));
		StartCoroutine(SetState(320, EventStage.NIGHTMARE));
	}
}

