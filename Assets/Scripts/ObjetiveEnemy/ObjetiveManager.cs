using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetiveManager : MonoBehaviour {

    //**Script que controla el tiempo de Spawn
    //**Referencia video: 11 - Generando Enemigos - Tutorial Survival Shooter en Unity

    //crear script PlayerPoints (PlayerHealth originalmente). 
    //Esto determinara si termina el juego por quedar sin puntos el juego termina y deja de crear objetivos.
    //public PlayerPoint playerPoint;

    //Referencia al objetivo prefab
    public GameObject objetive;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;

	
	void Start ()
    {
        //Esto programa la llamada al metodo de abajo Spawn cada cierto tiempo.
        InvokeRepeating("Spawn", spawnTime, spawnTime);
	}
	
	void Spawn ()
    {
        //Comprobar si el jugador perdio o murio -> sale de la funcion.
        //if (playerPoint.currentPoint <= 0f)
        //{
        //    return;
        //}

        //Elegir aleatoriamente una posicion de todos los elementos en el vector spawnPoints (depende de cuantos puntos de Spawn hay en la scena)
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        //Instanciar el prefab al q se haga referencia en la posicion + la rotacion
        Instantiate(objetive, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
	}
}
