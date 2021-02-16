using UnityEngine;
using System.Collections;

/**
 * Skkrypt powodujący usunięcie obiektu po upływie zadanego czasu.
 */
public class Autodestruction : MonoBehaviour {

	//Czas życia obiektu posiadającego ten skrypt.
	public float lifeTime = 1f;

	// Update is called once per frame
	void Update () {
		lifeTime -=Time.deltaTime;

		//Czy upłyną czas życia.
		if(lifeTime <=0){
			//Czas zycia upłyną usuń obiekt.
			Destroy(gameObject);
		}
	}

}
