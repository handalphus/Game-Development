using UnityEngine; // required component -> physics -> rigidbody
using System.Collections;

public class AIController : MonoBehaviour { 

	//speed of enemy's rotation
	public float speedOfRotation = 6.0f;

	//Gładki obrót przeciwnika
	public bool smoothRotation = true;


	//Prędkość poruszania się przeciwnika.
	public float speedOfMovement = 5.0f; 
	//Odległość na jaką widzi przeciwnik.
	public float sightRange = 30f;
	//Odstęp w jakim zatrzyma się obiekt wroga od gracza.
	public float distanceFromPlayer = 2f;

	private Transform myObject; 
	private Transform player;
	private bool lookAtPlayer = false;
	private Vector3 playerPositionXYZ;
	private float attackRange = 2f;
	// Use this for initialization
	void Start () {
		myObject = transform; 
		//Rigidbody pozwala aby na obiekt oddziaływała fizyka.
		//Wyłaczenie oddziaływanie fizyki na XYZ - 
		// jak obiekt będzie wchodził pod górkę to się przechyli prostopadle do zbocza a fizyka pociągnie go w dół i
		// obiekt się przewróci. POZATYM NIE CHCEMY ABY WRÓG SIĘ TAK DZIWNIE OBRACAŁ ;).
		if (GetComponent<Rigidbody> ()) {
			GetComponent<Rigidbody> ().freezeRotation = true;
		}
	}

	// Update is called once per frame
	void Update () {
		//Pobranie obiektu gracza.
		player = GameObject.FindWithTag("Player").transform; //zmienić Player na tag przypisany do obiektu gracza
		PlayerHealth hp = player.GetComponent<PlayerHealth>();
		//Pobranie pozycji gracza.
		playerPositionXYZ = new Vector3(player.position.x, myObject.position.y, player.position.z);

		//Pobranie dystansu dzielącego wroga od obiektu gracza.
		float dist = Vector3.Distance (myObject.position, player.position);

		lookAtPlayer = false; //Wróg nie patrz na gracza bo jeszcze nie wiadomo czy jest w zasięgu wzroku.

		//Sprawdzenie czy gracz jest w zasięgu wzroku wroga.
		if(dist <= sightRange && dist > distanceFromPlayer) {
			lookAtPlayer = true;//Gracz w zasiegu wzroku wiec na neigo patrzymy

			//Teraz wykonujemy ruch wroga.
			//Vector3.MoveTowards - pozwala na zdefiniowanie nowej pozycji gracza oraz wykonanie animacji.
			//Pierwszy parametr obecna pozycja drógi parametr pozycja do jakiej dążymy (czyli pozycja gracza).
			//Trzeci parametr określa z jaką prędkością animacja/ruch ma zostać wykonany.
			myObject.position = Vector3.MoveTowards(myObject.position, playerPositionXYZ, speedOfMovement * Time.deltaTime);

		} else if(dist <= distanceFromPlayer && !isDead()) { //Jeżeli wróg jest tuż przy graczu to niech ciągle na niego patrzy mimo że nie musi się już poruszać.
			lookAtPlayer = true;
		}
        if (dist <attackRange)
        {
			
			if (Random.Range(1, 50) == 1)
			{
				hp.receiveDamage(10);
				
			}
			
		}
		
        if (!isDead())
        {
			lookAtMe();
        }
        else
        {
            if (gameObject.tag == "Bear")
            {
				player.GetComponent<PlayerHealth>().playerScore += 20; 
            }
            else
            {
				player.GetComponent<PlayerHealth>().playerScore += 10;
			}
			
			Destroy(gameObject);
		}
		
	}

	//Wróg może nie mieć potrzeby sie pruszać bo jest blisko gracza ale niech się obraca w jego stronę.
	void lookAtMe(){
		if (smoothRotation && lookAtPlayer == true){

			//Quaternion.LookRotation - zwraca quaternion na podstawie werktora kierunku/pozycji. 
			//Potrzebujemy go aby obrócić wroga w stronę gracza.
			Quaternion rotation = Quaternion.LookRotation(playerPositionXYZ - myObject.position);
			//Obracamy wroga w stronę gracza.
			myObject.rotation = Quaternion.Slerp(myObject.rotation, rotation, Time.deltaTime * speedOfRotation);
		} else if(!smoothRotation && lookAtPlayer == true){ //Jeżeli nei chcemy gładkiego obracania się wroga tylko błyskawicznego obrotu.

			//Błyskawiczny obrót wroga.
			transform.LookAt(playerPositionXYZ);
		}

	}
	bool isDead()
	{
		Health h = gameObject.GetComponent<Health>();
		if (h != null)
		{
			return h.isDead();
		}
		return false;
	}
}