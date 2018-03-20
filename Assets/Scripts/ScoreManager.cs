using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public static int score;

    TextMesh text;
	
	void Awake ()
    {
        text = GetComponent<TextMesh>();

        //Resetea el score
        score = 0;
	}
	
	void Update ()
    {
		
	}
}
