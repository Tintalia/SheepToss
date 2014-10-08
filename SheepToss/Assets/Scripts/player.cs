using UnityEngine;
using System.Collections;

public abstract class NewBehaviourScript : MonoBehaviour {
	public int health;

	protected abstract void Move();
}
