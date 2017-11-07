using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour {

	// Use this for initialization
	public float life = 10;


	public void ReceiveDamage(float damage)
	{
		life -= damage;
	}
}
