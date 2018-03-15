using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour {

    public float magnitudRotation; //multiplicador de velocidad de giro
    private Rigidbody rig;

	// Use this for initialization
	void Awake ()
    {
        rig = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Elije un punto aleatorio dentro del area de una esfera de radio 1 (al no normalizar no tendra siempre la misma velocidad de giro)
        rig.angularVelocity = Random.insideUnitSphere * magnitudRotation;

        //Si quisieramos el valor normalizado para todos los Enemigos o Objetivos deberia escribir Random.InsideUnitSphere.normalized.
	}
}
