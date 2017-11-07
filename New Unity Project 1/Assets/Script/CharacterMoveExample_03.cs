/*
 * Author: fernando urquijo 
 * date creation: 20/10/17
 * mail: furquijos@gmail.com
 * 
 * Mueve al personaje usando el componente CharacterController, movimiento relativo al mundo discretizado
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterMoveExample_03 : MonoBehaviour {
	public float displacement = 3.0F;
	Vector3 movement;



	void Update() {

		//Setamos el vector3 a (0,0,0)
		movement = Vector3.zero;

		//Generamos un vector desplazamiento a partir de la lectura de las flechas del teclado
		if(Input.GetKeyDown(KeyCode.DownArrow)){
			movement += Vector3.forward;
		}else if(Input.GetKeyDown(KeyCode.UpArrow)){
			movement += Vector3.back;
		}

		if(Input.GetKeyDown(KeyCode.RightArrow)){
			movement += Vector3.right;
		}else if(Input.GetKeyDown(KeyCode.LeftArrow)){
			movement += Vector3.left;
		}



		//Movemos nuestro personaje en dirección al Input dado con un desplazamiento fijo dado por la variable pública displacement
		transform.Translate(movement* displacement);


	}
}
