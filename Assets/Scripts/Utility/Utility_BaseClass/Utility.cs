using UnityEngine;
using System.Collections;

public abstract class Utility : MonoBehaviour
{
	public enum UtilityState {}
	protected bool isPowered;

	abstract public bool TogglePower();
	abstract public void CheckPower(bool curPowerState);
	abstract public void ChangeState(UtilityState state);
}

