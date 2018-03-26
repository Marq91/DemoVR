using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverManager : CountdownTimer {
    //**Clase modificada heredada de MonoBehaviour a CountdownTimer

    //public PlayerPoints playerPoint;       // Se puede reemplazar tiempo por current points.

    public GameObject contadorTime;
    
    //Animator anim;                          // Reference to the animator component.
    public TextMesh gameOverText;

    void Start()
    {
        // Set up the reference.
        //anim = GetComponent <Animator> ();
        gameOverText.text = "";

        //Inchildren prueba
        //CountdownTimer cont = GetComponentInChildren<CountdownTimer>();

        contadorTime = GameObject.Find("tiempo");

        if (tiempo <= 0)
        {
            gameOverText.text = "Game Over";
        }
    }
    
    void Update()
    {
        // If the player has run out of health...
        //if (playerPoint.currentPoint <= 0)
        //{
        //    // ... tell the animator the game is over.
        //    //anim.SetTrigger ("GameOver");
        //    gameOverText.text = "Game Over";
        //}
    }
}
