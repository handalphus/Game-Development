using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Canvas Victory;
    private Canvas menu;
    private GameManager gm;
    public FirstPersonController controller;
    // Start is called before the first frame update

    private Canvas hud;
    void Start()
    {
      
        controller = controller.GetComponent<FirstPersonController>();
        menu = (Canvas)GetComponent<Canvas>();
        gm = FindObjectOfType<GameManager>();
        menu.enabled = false;
        Victory = Victory.GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.isGameEnded == true)
        {
            gm.isGameActive = false;
            Time.timeScale = 0;
            controller.enabled = false;
            menu.enabled = true;
            Cursor.visible = menu.enabled;
            Cursor.lockState = CursorLockMode.Confined;
            
        }
          
    }

    public void Replay()
    {
        gm.isGameActive = true;
        gm.isGameEnded = false;
        gm.isGameWon = false;
        menu.enabled = false;
        controller.enabled = true;
        PlayerHealth h = controller.GetComponent<PlayerHealth>();
        h.health = 100;
        h.lives = 3;
        h.playerScore = 0;
        h.respawn();
        Victory.enabled = false;
        //FindObjectOfType<Menu>().enabled = false;
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void Exit()
    {
        Application.Quit();
    }
}
