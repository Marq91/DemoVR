using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Destruir el Objeto que contiene el Script luego de un tiempo.
public class DestroyByTime : MonoBehaviour {

    public float lifeTime;

    void Start()
    {
        Destroy(gameObject, lifeTime);    //El script sirve tanto para objetivos como para Efectos.

    }
}
