using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class HUDCanvas : MonoBehaviour
{
    public Slider slider;
    public Text livesText;
    public Text scoreText;
    public FirstPersonController controller;
    private GameManager gm;
    private Canvas hud;
    private PlayerHealth ph;
    // Start is called before the first frame update
    void Start()
    {
        hud = (Canvas)GetComponent<Canvas>();
        slider = slider.GetComponent<Slider>();
        slider.maxValue = 100;
        slider.minValue = 0;
        
        hud.enabled = false;
        ph = controller.GetComponent<PlayerHealth>();
        gm = FindObjectOfType<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (gm.isGameActive)
        {
        hud.enabled = true;

        //gm.isGameActive = false;
        slider.value = ph.health;
        livesText.text = "LIVES: " + ph.lives;
        scoreText.text = "SCORE: " + ph.playerScore;
        }
    }
}
