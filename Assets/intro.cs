using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class intro : MonoBehaviour
{
    public Button startButton;
    public FirstPersonController controller;
    private GameManager gm;
    private Canvas introCanvas;

    void Start()
    {
        introCanvas = (Canvas)GetComponent<Canvas>();
        gm = FindObjectOfType<GameManager>();
        gm.isGameActive = false;
        controller = controller.GetComponent<FirstPersonController>();
        startButton = startButton.GetComponent<Button>();

    }
    public void StartButton()
    {
        introCanvas.enabled = false;
        Time.timeScale = 1;
        gm.isGameActive = true;
        gm.isGameEnded = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        controller.enabled = true;
    }

}
