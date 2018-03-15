using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
       
        //excluir el terreno segun el tag Terrain. No se ejecutaran las lineas de abajo si se cumple el if 
        if (other.tag == "Terrain") return;
        //Destruir el objeto de disparo
        Destroy(other.gameObject);
        //destruir el Objetivo (sphera, prefab ,**Terreno)
        Destroy(gameObject);
    }
}
