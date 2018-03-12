using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickUp : MonoBehaviour {

    public GameObject myWeapon;
    public GameObject weaponOnGround;

	void Start ()
    {
        myWeapon.SetActive(false);
	}

    void OnTriggerEnter(Collider _collider)
    {
        if (Input.GetButton("Fire1"))
        {
            if (_collider.gameObject.tag == "Player")
            {
                Debug.Log("Arma Activa");
                myWeapon.SetActive(true);
                weaponOnGround.SetActive(false);

                //destruir el arma
                //weaponOnGround.SetActive(false);
            }
        }
        
    }


}
