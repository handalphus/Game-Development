using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

   public bool isGameActive = false;
   public bool isGameEnded = false;

   public bool isGameWon = false;
   public void EndGame()
    {
        
        Debug.Log("game over");
        isGameEnded = true;
       
    }

    public bool isLocationWon(float x, float z)
    {
        return x < 450 && x > 425 && z > 306 && z < 336;
    }
}
