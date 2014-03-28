using UnityEngine;
using System.Collections;

public abstract class Trap : MonoBehaviour
{
	protected bool isActive;

	abstract public void AffectPlayer();
	abstract public bool ToggleState();
	abstract public void CheckState(bool _isActive);
}

