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
public class SimpleMove : MonoBehaviour {
	public float speed = 3.0F;
	public float rotateSpeed = 3.0F;
	CharacterController controller;
	Animator animator;

	// Use this for initialization
	void Start () {
		//Bakeamos el componente en la variable controller
		controller = GetComponent<CharacterController>();
		animator =  GetComponent<Animator>();
		if (animator == null)
			Debug.Log ("Aniamtor not atacched to " + gameObject.name.ToString ()); 

	}

	void Update() {
		//Vemos en la función Input.GetAxis, que nos referimos a Horizontal, un Input ya predefinido por Unity, y que nos da un
		//valor entre -1 y 1 dependiendo de si estamos pulasando a la "derecha" o a la "izquierda" y lo rotamos en el eje Y
		//Obtenemos 
		//Convertimos el Input del joystick en vectores de deplazamiento vertical y horizontal
		Vector3 forward = transform.TransformDirection(Vector3.forward)* Input.GetAxis("Vertical") ;
		Vector3 horizontal = transform.TransformDirection(Vector3.right) * Input.GetAxis("Horizontal") ;
		Vector3 up = Vector3.up;
		if (Input.GetKeyDown(KeyCode.Space))
			up = Vector3.up * 10000f;
		//Aplicamos la suma de ambos al character controller
		controller.SimpleMove((forward +horizontal + up)* speed);

		float movementValue = Vector3.SqrMagnitude (forward + horizontal);
		animator.SetFloat ("Blend",movementValue);
	
			

		//Ahora rotamos el personaje  en dirección al movimiento, es importante daros cuenta que esta rotación 
		//no cambia la dirección de movimiento del personaje, ya que se mueve respecto al mundo
		if (movementValue > 0.1f) {
			Quaternion wanted_rotation = Quaternion.LookRotation (forward + horizontal);
			transform.rotation = Quaternion.RotateTowards (transform.rotation, wanted_rotation, rotateSpeed * Time.deltaTime);
		}
	}
}