using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPruebaSpawn : MonoBehaviour {

    //Instancia 2
    public Rigidbody objetivePrefab;
    public Transform spawner;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Instancia 2
        Rigidbody objectiveInstance;
        objectiveInstance = Instantiate(objetivePrefab, spawner.position, spawner.rotation) as Rigidbody;
        //Añadir Fuerza al objeto Instanciado
        objectiveInstance.AddForce(spawner.up * 50);
    }
}
