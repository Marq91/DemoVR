using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour {

    //Se cambio Text contador a TextMesh contador
    public Text contador;
    public float tiempo;      //protected float tiempo = 60f;

    //Prueba get 1
    //public float getMiCount()
    //{
    //    return tiempo;
    //}

    void Start()
    {
        //contador.text = " " + tiempo;
    }

    public void AddTime()
    {
        //metodo para en el futuro agregar tiempo (int value){ }
    }

    
    void Update()
    {
        //Antes
        //tiempo -= Time.deltaTime;
        //contador.text = " " + tiempo.ToString("f0");

        //Antes
        // if (tiempo <= 0)
        //{
        //tiempo = 0;
        //}
 
        //Fin count
        if (tiempo > 0)
        {
            tiempo -= Time.deltaTime;
            contador.text = " " + tiempo.ToString("f0");
        }
        else
	    { 
            tiempo = 0;
            //Llama a singleton desde el GameOverManager
            GameOverManager.instance.OnTimerOut("Game Over");
        }
    }
}
