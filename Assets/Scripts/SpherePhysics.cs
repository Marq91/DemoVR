using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpherePhysics : MonoBehaviour {

    private Rigidbody rig;

	// Use this for initialization
	void Start ()
    {
        rig = GetComponent<Rigidbody>();
        float randomSpawn = Random.Range(-2f, 2f);
        rig.AddForce(new Vector3(0f, 1f, randomSpawn) * 1f, ForceMode.Impulse);
    }
	
	// Update is called once per frame
	void Update ()
    {
        

    }
}
