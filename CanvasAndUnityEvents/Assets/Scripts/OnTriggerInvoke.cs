using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class OnTriggerInvoke : MonoBehaviour {

	public string tag;
	public  UnityEvent eventOnCollision;


	


	void OnTriggerEnter(Collider collision)
	{
		if (collision.gameObject.tag == tag) {
			eventOnCollision.Invoke ();
		}
	}
}
