using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100.0f;
    public int lives = 3;
    
   
    private Terrain terrain;
    public Vector3 initPosition;
    public FirstPersonController player;
    public int playerScore = 0;
    
    private GameManager gm;
    
   
    private void Start()
    {
        terrain = FindObjectOfType<Terrain>();
        gm = FindObjectOfType<GameManager>();
       // player = FindObjectOfType<FirstPersonController>();
        initPosition = player.transform.position;
        
        Debug.Log(initPosition.ToString());
        
    } 
    public void receiveDamage(float damage)
    {
        if (health > 0)
        {
            health -= damage;
          
        }
        if (health <= 0f && !gm.isGameEnded)
        {
            lives--;
            Debug.Log(lives);
           
            if (lives <= 0)
            {
                Debug.Log(gm.isGameEnded);
                FindObjectOfType<FirstPersonController>().enabled = false;
                gm.EndGame();
            }
            else
            {
                Debug.Log("respawn");
                Debug.Log(initPosition);
                health = 100;
                // GameObject p = GameObject.FindGameObjectWithTag("Player");
                //Instantiate(p, initPosition, Quaternion.identity);
                respawn();
                Debug.Log(player.transform.position);
            }

        }
            
    }

    public void respawn()
    {
        player.GetComponent<CharacterController>().enabled = false;
        player.transform.position = initPosition;
        player.GetComponent<CharacterController>().enabled = true;
    }
    public void die()
    {

    }
    
}
