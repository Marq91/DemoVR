using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour {

    //Se cambio Text contador a TextMesh contador
    public Text contador;
    protected float tiempo = 60f;

    //Prueba get 1
    //public float getMiCount()
    //{
    //    return tiempo;
    //}

    void Start()
    {
        contador.text = " " + tiempo;
    }

    void Update()
    {
        tiempo -= Time.deltaTime;
        contador.text = " " + tiempo.ToString("f0");

        //Fin count
        if (tiempo <= 0)
        {
            tiempo = 0;
            //Do something cool!
            //contador.color.ToColorf();
        }
    }
}
