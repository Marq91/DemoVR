using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactables : MonoBehaviour
{
    public bool interactable = false;

    public Material[] material;
    Renderer rend;

    //obtener el objeto
    //public GameObject weaponObj;

    public GameObject myWeapon;
    public GameObject weaponOnGround;

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];

        //weaponObj = GetComponent<GameObject>();

        myWeapon.SetActive(false);
    }

    public void Interact()
    {
        //O deshabilitar
        gameObject.SetActive(false);

        //Destruye el objeto Interactable
        //Destroy(gameObject);

        //**Se debe programar Enable(Habilitar) el objeto Gun en la Mano derecha 
        //...del personaje en este Script y en comunicarse con el Script de HolderWeapon 
    }

    void Update()
    {
        //Checkear si el objeto es interactable y presionar el boton correcto
        if (interactable && Input.GetButton("Fire1"))
        {
            Interact();
        }
        if (interactable)
        {
            //si es interactable cambia el material a index 1
            rend.sharedMaterial = material[1];
        }
        else
        {
            //si no es interactable muestra el index 0 el cual no contiene modificacion
            rend.sharedMaterial = material[0];
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //detecta el collider
        if (other.gameObject.tag == "Player")
        {
            interactable = true;

            //if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger)) //este boton no esta funcionando

            //Prueba habilitar / Deshabilitar

            myWeapon.SetActive(true);
            weaponOnGround.SetActive(false);

        }
    }

    void OnTriggerExit(Collider other)
    {
        //detecta el collider
        if (other.gameObject.tag == "Player")
        {
            interactable = false;
        }
    }

}
