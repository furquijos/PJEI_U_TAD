/*
 * Author: fernando urquijo 
 * date creation: 20/10/17
 * mail: furquijos@gmail.com
 * 
 * Mueve al personaje usando el componente CharacterController, movimiento relativo al mundo
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]
public class CharacterMoveExample_02 : MonoBehaviour {
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
		//Obtenemos 
		//Convertimos el Input del joystick en vectores de deplazamiento vertical y horizontal
		Vector3 forward = Vector3.forward * Input.GetAxis("Vertical") ;
		Vector3 horizontal = Vector3.right * Input.GetAxis("Horizontal") ;

		//Aplicamos la suma de ambos al character controller
		controller.SimpleMove((forward +horizontal)* speed);


		//Ahora rotamos el personaje  en dirección al movimiento, es importante daros cuenta que esta rotación 
		//no cambia la dirección de movimiento del personaje, ya que se mueve respecto al mundo
		Quaternion wanted_rotation = Quaternion.LookRotation(forward +horizontal);
		transform.rotation = Quaternion.RotateTowards(transform.rotation, wanted_rotation,  rotateSpeed * Time.deltaTime);
	}
}
