using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public static int score;

    TextMesh text;      //Originalmente era Text text;
	
	void Awake ()
    {
        text = GetComponent<TextMesh>();    //Originalmente era text = GetComponent<Text>();

        //Resetea el score
        score = 0;
	}
	
    //Falta codigo mas abajo
	void Update ()
    {
		
	}
}
