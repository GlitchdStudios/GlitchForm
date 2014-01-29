using UnityEngine;
using System.Collections;

public class OrthographicSize : MonoBehaviour
{
	private ScreenBounds screenBounds;
	private WorldtoScreen worldtoScreen;
	public GameObject playerObj;

	void Awake()
	{
		camera.orthographicSize = ((Screen.height / 100f)/ 2.0f); // 100f is the PixelPerUnit that you have set on your sprite. Default is 100.
		worldtoScreen = GetComponent<WorldtoScreen>();
		worldtoScreen.SetWorldtoScreen();
	}

	void Start ()
	{

		screenBounds = new ScreenBounds();
		screenBounds.worldtoScreen = GetComponent<WorldtoScreen>();
		screenBounds.player = playerObj;
	
		screenBounds.ship = playerObj.GetComponentsInChildren<Renderer>();
		screenBounds.GetShipSize();

		screenBounds.SetBounds();
	}

	void Update ()
	{
		screenBounds.Boundary();
	}
}

public class ScreenBounds : MonoBehaviour
{
	public WorldtoScreen worldtoScreen;
	public float top;
	public float bottom;
	public float left;
	public float right;
	public Renderer[] ship;
	public GameObject player;

	private Vector3 shipSize;

	public void GetShipSize()
	{
		for(int i = 1; i < ship.Length-1; i++)
		{
		  shipSize.x += ship[i].bounds.extents.x;
		}

		shipSize.y = ship[3].bounds.extents.y;
	}

	public virtual void Boundary()
	{
		player.transform.position = new Vector3( 	Mathf.Clamp(player.transform.position.x, left, right),
		                                        	Mathf.Clamp(player.transform.position.y, bottom, top),
		                                        	player.transform.position.z);	
	}
	
	public virtual void SetBounds()
	{
		top = worldtoScreen.top - shipSize.y;
		bottom = worldtoScreen.bottom + shipSize.y;
		left = worldtoScreen.left + shipSize.x;
		right = worldtoScreen.right - shipSize.x;
	}
}
