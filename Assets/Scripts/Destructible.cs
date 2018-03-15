using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour {

    public GameObject destroyedVersion;

    //if the player clicks on the object
    public void Destroy()
    {
        //Spawn a shattered object
        Instantiate(destroyedVersion, transform.position, transform.rotation);
        //Remove the current object
        Destroy(gameObject);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
