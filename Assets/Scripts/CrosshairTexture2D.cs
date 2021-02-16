using UnityEngine;
using System.Collections;

/**
 * Klasa odpowiedzialna za narysowanie/wyœwietlenie celownika przy u¿yciu jego tekstury.
 */
public class CrosshairTexture2D : MonoBehaviour {

	/* Pod t¹ zmienn¹ podstawiamy obrazek*/
	public Texture2D crosshairTexture; 
	/*Pozycja naszego celownika.*/
	public Rect position;
	public Canvas menu;
	public Canvas gameOver;
	public Canvas victory;
	/** Czy wyœwietliæ celownik.*/
	public bool isVisible = false;
	
	void Start(){
		//Ustawienie pozycji dla celownika.
		position = new Rect(
			(Screen.width - crosshairTexture.width) / 2, 
			(Screen.height - crosshairTexture.height) /2, 
			crosshairTexture.width, crosshairTexture.height);
	}

	/**
	 * Metoda pozwala rejestrowaæ zdarzenia interfejsu u¿ytkownika.	 * 
	 */
	void OnGUI(){
		//Czy pokazaæ celownik.
		if (!menu.enabled && !gameOver.enabled && !victory.enabled) {
			//Rysowanie celownika.
			GUI.DrawTexture (position, crosshairTexture); 
		}
	}
}
