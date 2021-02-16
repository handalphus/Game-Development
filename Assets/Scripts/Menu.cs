using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class Menu : MonoBehaviour
{
    public Button exitButton;
    public Button startButton;
    public Text startText;
    public FirstPersonController controller;
    public Canvas intro;
    private Canvas menu;
    private bool isFirstTime = true;
    private GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        menu = (Canvas)GetComponent<Canvas>();
        gm = FindObjectOfType<GameManager>();
        gm.isGameActive = false;
        startButton = startButton.GetComponent<Button>();
        exitButton = exitButton.GetComponent<Button>();
        controller = controller.GetComponent<FirstPersonController>();
        intro = intro.GetComponent<Canvas>();
        intro.enabled = false;
        controller.enabled = false;
        Cursor.visible = menu.enabled;
        Cursor.lockState = CursorLockMode.Confined;
        Time.timeScale = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape) && !gm.isGameWon && !gm.isGameEnded)
        {
            Debug.Log("jadymy");
            menu.enabled = !menu.enabled;
            Cursor.visible = menu.enabled;
            gm.isGameActive = false;

            if (menu.enabled)
            {
                controller.enabled = false;
                if (!isFirstTime)
                {
                    startText.text = "CONTINUE";
                }
                Cursor.lockState = CursorLockMode.Confined;
                
                Time.timeScale = 0;
            }
            else
            {
                controller.enabled = true;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                Time.timeScale = 1;
            }
        }
        
    }
    public void StartButton()
    {
        menu.enabled = false;

        if (isFirstTime)
        {
            isFirstTime = false;
            intro.enabled = true;
        }
        else 
        { 
        Time.timeScale = 1;
        gm.isGameActive = true;
        gm.isGameEnded = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        controller.enabled = true;
        //startButton.enabled = true;
        }

    }

    public void ExitButton()
    {
        startButton.enabled = false;
        exitButton.enabled = false;
        Application.Quit();
    }
}
