using UnityEngine;
using System.Collections;

/**
 * Klasa odpowiedzialna za narysowanie/wy�wietlenie celownika przy u�yciu jego tekstury.
 */
public class CrosshairTexture2D : MonoBehaviour {

	/* Pod t� zmienn� podstawiamy obrazek*/
	public Texture2D crosshairTexture; 
	/*Pozycja naszego celownika.*/
	public Rect position;
	public Canvas menu;
	public Canvas gameOver;
	public Canvas victory;
	/** Czy wy�wietli� celownik.*/
	public bool isVisible = false;
	
	void Start(){
		//Ustawienie pozycji dla celownika.
		position = new Rect(
			(Screen.width - crosshairTexture.width) / 2, 
			(Screen.height - crosshairTexture.height) /2, 
			crosshairTexture.width, crosshairTexture.height);
	}

	/**
	 * Metoda pozwala rejestrowa� zdarzenia interfejsu u�ytkownika.	 * 
	 */
	void OnGUI(){
		//Czy pokaza� celownik.
		if (!menu.enabled && !gameOver.enabled && !victory.enabled) {
			//Rysowanie celownika.
			GUI.DrawTexture (position, crosshairTexture); 
		}
	}
}
