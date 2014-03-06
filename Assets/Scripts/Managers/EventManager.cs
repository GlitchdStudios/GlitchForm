using UnityEngine;
using System.Collections;

public enum EventStage {NORMAL, HARD, VERY_HARD, IMPOSSIBLE, NIGHTMARE};

public class EventManager : Singleton<EventManager>
{
	private EventStage curEvent;

	public float gameTime;

	void Start()
	{
		StartEvent(EventStage.NORMAL);
		DontDestroyOnLoad(gameObject);
	}

	// Update is called once per frame
	void FixedUpdate ()
	{
		SetupEvent();

		if(Application.loadedLevel == 1)
		{
			gameTime = Time.time;
		}

		Debug.Log(gameTime);
	}

	private void StartEvent(EventStage eventStage)
	{
		switch(eventStage)
		{
			case EventStage.NORMAL:
				StartCoroutine(AsteroidManager.Instance.CreateAsteroids(eventStage));
			break;

			case EventStage.HARD:
				AsteroidManager.Instance.CreateMonsterRoid();
				AsteroidManager.Instance.gameObject.SetActive(false);
			break;

			case EventStage.VERY_HARD:
				
			break;

			case EventStage.IMPOSSIBLE:

			break;

			case EventStage.NIGHTMARE:

			break;
		}

		curEvent = eventStage;
	}

	public void SetupEvent()
	{
		if(gameTime == 20)
		{
			StartEvent(EventStage.HARD);
		}

		else if(gameTime >= 240)
		{
			StartEvent(EventStage.VERY_HARD);
		}

		else if(gameTime >= 480)
		{
			StartEvent(EventStage.IMPOSSIBLE);
		}

		else if(gameTime >= 960)
		{
			StartEvent(EventStage.NIGHTMARE);
		}
	}

	public EventStage CurEvent {get{return curEvent;}}
}

