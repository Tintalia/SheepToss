using UnityEngine;
using System.Collections;

public class NightFury : NewBehaviourScript {
	void Update(){
		Move ();
	}
	protected override void Move(){
		Debug.Log("Hello");
		var horz = Input.GetAxis("Horizontal");
		var vert = Input.GetAxis("Vertical");
		transform.position += (transform.right * horz + transform.up * vert) * 10 * Time.deltaTime;

	}
}
