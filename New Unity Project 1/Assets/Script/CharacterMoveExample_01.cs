/*
 * Author: fernando urquijo 
 * date creation: 20/10/17
 * mail: furquijos@gmail.com
 * 
 * Mueve al personaje usando el componente CharacterController, movimiento relativo al personaje
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]
public class CharacterMoveExample_01 : MonoBehaviour {
	public float speed = 3.0F;
	public float rotateSpeed = 3.0F;
	CharacterController controller;

	// Use this for initialization
	void Start () {
		//Bakeamos el componente en la variable controller
	 controller = GetComponent<CharacterController>();

	}

	void Update() {
		//Vemos en la función Input.GetAxis, que nos referimos a Horizontal, un Input ya predefinido por Unity, y que nos da un
		//valor entre -1 y 1 dependiendo de si estamos pulasando a la "derecha" o a la "izquierda" y lo rotamos en el eje Y
		transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);
		//Cogemos el vector "hacia donde encara" nuestro personaje
		Vector3 forward = transform.TransformDirection(Vector3.forward);

		float curSpeed = speed * Input.GetAxis("Vertical");
		controller.SimpleMove(forward * curSpeed);
	}
}
