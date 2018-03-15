using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granade : MonoBehaviour {

    public float delay = 3f;
    public float radius = 5f;
    public float force = 700f;

    public GameObject explosionEffect;

    float countdown;
    bool hasExploded = false;

    //***Estan realizados los pasos 2 y 3 
    //falta realizar el lanzamiento de
	
	void Start () {
        countdown = delay;

	}
	
	// Update is called once per frame
	void Update () {
        countdown -= Time.deltaTime;
        if (countdown <= 0f && !hasExploded)
        {
            Explode();
            hasExploded = true;
        }
	}

    void Explode()
    {
        // show effect
        Instantiate(explosionEffect, transform.position, transform.rotation);

        //get nearby objects
        Collider[] collidersToDestroy = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearByObject in collidersToDestroy)
        {
            
            //damage

            //Acceder al script Destructible.cs
            Destructible dest = nearByObject.GetComponent<Destructible>();
            if (dest != null)
            {
                dest.Destroy();
            }

        }

        Collider[] collidersToMove = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearByObject in collidersToMove)
        {
            //add force
            Rigidbody rb = nearByObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(force, transform.position, radius);
            }
        }

        //remove granade
        Destroy(gameObject);
      
    }
}
