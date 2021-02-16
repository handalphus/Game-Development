using UnityEngine;
using System.Collections;

/**
 * Skrypt odpowiedzialny za zadanie obrażen obiektowi z którym koliduje 
 * obiekt zawierający dany skrypt.
 */
public class Damage : MonoBehaviour {

	public float damage = 20f;

	/**
	 * Metoda wywoływana w chwili nastąpienia kolizji z obiketem.
	 */
	void OnCollisionEnter(Collision contact ){    
		GameObject go = contact.gameObject;
		Health health = (Health) go.GetComponent<Health>();
		if (health != null) {
			health.receivedDamage(damage);
		}
	}


}
