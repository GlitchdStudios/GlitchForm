using UnityEngine;
using System.Collections;

public class BaseEntity : MonoBehaviour
{
	protected int baseHealth;
	protected int baseDamage;
	protected int drawOrder;

	public float baseSpeed;

	public int Damage {set {baseDamage = value;} get {return baseDamage;}}
	public int Health {set {baseHealth = value;} get {return baseHealth;}}
	public float Speed {set {baseSpeed = value;} get {return baseSpeed; }}
}

