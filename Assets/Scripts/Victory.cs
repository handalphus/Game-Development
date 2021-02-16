using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class Victory : MonoBehaviour
{
    private Canvas menu;
    private GameManager gm;
    public FirstPersonController controller;
    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        controller = controller.GetComponent<FirstPersonController>();
        menu = (Canvas)GetComponent<Canvas>();
        gm = FindObjectOfType<GameManager>();
        menu.enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        gm.isGameWon = gm.isLocationWon(controller.transform.position.x,
           controller.transform.position.z);

        if (gm.isGameWon)
        {
            scoreText.text = "YOUR SCORE: " + controller.GetComponent<PlayerHealth>().playerScore;
            Time.timeScale = 0;
            controller.enabled = false;
            menu.enabled = true;
            Cursor.visible = menu.enabled;
            Cursor.lockState = CursorLockMode.Confined;

        }
    }
    public void Exit()
    {
        Application.Quit();
    }
}
