using UnityEngine;
using System.Collections;

/**
 * Skrypt zdrowia.
 * Jezeli obiekt ma ten skrypt to znaczy, że ma zdrowie ktore mozna mu zabrac.
 */
public class Health : MonoBehaviour {

	//Punkty zdrowia.
	public float health = 100.0f;

	//Zadanie obrażeń.
	public void receivedDamage(float damage) {
		//Odięcie od zdrowia punktów zadanych obrażeń.
		health -= damage;
		//Jeżeli zdrowie równe zero to obiekt do usunięcia.
		/*if(zdrowie <=0){
			Die();
		}*/	
	}
	
	public void Die(){
		Destroy(gameObject);	
	}

	public bool isDead(){
		if (health <= 0) {
			return true;
		}
		return false;
	}

}
