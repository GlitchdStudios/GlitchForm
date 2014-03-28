using UnityEngine;
using System.Collections;

public abstract class Utility : MonoBehaviour
{
	protected bool isActive;

	abstract public bool ToggleState();
	abstract public void CheckState(bool _isActive);
}

