using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {

    public GameObject prefab;

	// Use this for initialization
	void Start () {

        Instantiate(prefab, transform.position, transform.rotation);
	}
	
	// Update is called once per frame
	void Update ()
    {
        
	}
}
