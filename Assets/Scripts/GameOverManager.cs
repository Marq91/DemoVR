using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour {
    //**Clase modificada heredada de MonoBehaviour a CountdownTimer
    
    public TextMesh gameOverText;

    public static GameOverManager instance = null;

    void Awake()
    {
        //Probando instance
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }

        gameOverText.gameObject.SetActive(false);

        DontDestroyOnLoad(gameObject);

    }
    
    public void OnTimerOut(string message)
    {
        gameOverText.gameObject.SetActive(true);
        gameOverText.text = message;
    }
}
