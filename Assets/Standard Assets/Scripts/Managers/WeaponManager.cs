using UnityEngine;
using System.Collections;

public class WeaponManager : MonoBehaviour
{
	private static int ammo = 20;
	private static float lifeTime = 2.0f;
	
	
    private static float rof;
	private static float projectileSpeed;

	   
	public static void SetVars(GameObject gameObject)
	{
		switch(gameObject.name)
		{
			case "MachineGun":
					rof = 0.1f;
					projectileSpeed = 10f;
			break;
					
		}
	}
	
	public static int Ammo 				{ get {return ammo;}  }
	public static float LifeTime 		{ get {return lifeTime;}  }
	
	public static float RoF 				{ set { rof = value; } get {return rof;}  }
	public static float ProjectileSpeed 	{ set { projectileSpeed = value; } get {return projectileSpeed;}  }
}

