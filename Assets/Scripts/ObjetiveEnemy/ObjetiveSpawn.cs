using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script ObjetiveSpawn= GameManager
public class ObjetiveSpawn : MonoBehaviour {

    //Variables Prueba corrutinas
    public GameObject hazardPrefab;  //antes era hazard
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;     //Espera entre instancia de objetivos
    public float startWait;     //Tiempo espera Inicial
    public float waveWait;      //Espera de Oleada

    void Start()
    {
        //Instantiate(hazardPrefab, transform.position, transform.rotation);
        StartCoroutine(SpawnWaves());
    }

    //Inicio Corrutina
    IEnumerator SpawnWaves()
    {
        //NO se ejecute hasta que pase el tiempo espera Inicial
        yield return new WaitForSeconds(startWait);

        //Un while de prueba para que sea un loop infinito
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                //Genera los objetivos en un area Aleatoria con Random.Range
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Instantiate(hazardPrefab, spawnPosition, Quaternion.identity);

                //Pospone la ejecucion de la corrutina hasta que pase este tiempo.
                yield return new WaitForSeconds(spawnWait);

            }

            //Esperar otro tiempo para esperar la Otra Oleada
            yield return new WaitForSeconds(waveWait);
        }

    }
}
