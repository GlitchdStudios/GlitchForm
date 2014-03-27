using UnityEngine;
using System.Collections;

public abstract class Trap : MonoBehaviour
{
	protected bool isPowered;
	protected bool isActive;

	abstract public void KillPlayer();
	abstract public bool TogglePower();
	abstract public void CheckPower(bool _isPowered);
	abstract public bool ToggleState();
	abstract public void CheckState(bool _isActive);
}

