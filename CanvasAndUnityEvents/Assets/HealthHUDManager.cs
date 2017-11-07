using UnityEngine;
using System.Collections;
using UnityEngine.UI; // Required when Using UI elements.

public class HealthHUDManager : MonoBehaviour
{
	public Slider mainSlider;
	public float maxValueTracked = 10f;
	public Life lifeTracked;
	public Image lifeFill;
	//Invoked when a submit button is clicked.
	void Update()
	{ 
		RefreshValue ();
	}
	public void RefreshValue()
	{
		mainSlider.value =(float) lifeTracked.life /maxValueTracked;
		lifeFill.color = Color.Lerp (Color.red, Color.green, mainSlider.value);
	}
}
