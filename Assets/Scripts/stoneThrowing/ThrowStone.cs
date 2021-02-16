using UnityEngine;
using System.Collections;

public class ThrowStone : MonoBehaviour
{

	//Obiekt kamienia.
	public GameObject stonePrefab;
	public Canvas menu;
	public float velocity = 50;
	public float wait = 2f;
	public float countTillThrow = 2f;
	private GameManager gm;

    private void Start()
    {
		gm = FindObjectOfType<GameManager>();
	}
    // Update is called once per frame
    void Update()
	{
		if (countTillThrow < wait)
		{
			countTillThrow += Time.deltaTime;
		}

		if (Input.GetMouseButton(0) && countTillThrow >= wait &&!menu.enabled && !gm.isGameWon)
		{ 
			countTillThrow = 0;
			GameObject stone;
			
			stone = (GameObject)Instantiate(stonePrefab, 
				Camera.main.transform.position + Camera.main.transform.forward, 
				Camera.main.transform.rotation);
			stone.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * velocity, ForceMode.Impulse);
		}
	}

}
