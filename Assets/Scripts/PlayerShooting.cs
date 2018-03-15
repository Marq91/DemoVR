using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {


    public int damagePerShot = 20;
    //tiempo entre disparos
    public float timeBetweenBullets = 0.15f;
    //distancia que la bala recorre
    public float range = 100f;

    //Econtar tiempo entre ultimo disparo
    float timer;
    //Descriopcion punto inicial y direccion del disparo
    Ray shootRay = new Ray();
    //Resultado objeto con el q colisiona
    RaycastHit shootHit;
    //representa las capas con los collider con los q colisiona
    int shootableMask;

    //Resto de variables de efectos
    ParticleSystem gunParticles;

    //Configurar LineRenderer simulacion bala en **Resto de script revisar referencias
    LineRenderer gunLine;

    AudioSource gunAudio;

    //**quitar efecto luz
    Light gunLight;

    float effectsDisplayTime = 0.2f;


    void Awake()
    {
        //hace referencia a Objetos disparables
        shootableMask = LayerMask.GetMask("Shootable");

        gunParticles = GetComponent<ParticleSystem>();
        gunLine = GetComponent<LineRenderer>();
        gunAudio = GetComponent<AudioSource>();

        //**quitar efecto luz
        gunLight = GetComponent<Light>();
    }


    void Update()
    {
        timer += Time.deltaTime;

        //Cambiar el boton por OVRInput
        //calcula si ha pasado tiempo entre disparos para nuevamente disparar y el Juego no esta pausado (&& Time.timeScale != 0)
        if (Input.GetButton("Fire1") && timer >= timeBetweenBullets && Time.timeScale != 0)
        {
            Shoot();
        }
        //Calcula si ha pasado tiempo para desactivar los efectos de disparo (luces efectos)
        if (timer >= timeBetweenBullets * effectsDisplayTime)
        {
            DisableEffects();
        }
    }


    public void DisableEffects()
    {
        gunLine.enabled = false;

        //**quitar efecto luz
        gunLight.enabled = false;
    }


    void Shoot()
    {
        //La logica de disparo se puede modificar por la de Space Shooter

        timer = 0f;

        //Ejecutar sonido
        gunAudio.Play();

        //**quitar efecto luz
        gunLight.enabled = true;

        gunParticles.Stop();
        gunParticles.Play();

        gunLine.enabled = true;
        gunLine.SetPosition(0, transform.position);

        //Con esto indicamos direccion y ubicacion de donde saldra el disparo
        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;

        //Comprobamos si la bala q disparamos colisiano con algun objeto
        //con shothit indicamos con q objetos coliciona nuestro disparo (Ademas se almacena la info en esta variable)
        //Asignar capa("Layer" al lado de Tag) "Shootable" a los Objetivos/Enemigos y al Escenario.
        if (Physics.Raycast(shootRay, out shootHit, range, shootableMask))
        {
            //Se debe corregir ya que el script EnemyHealt esat fuera de contexto
            //EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth>();
            //if (enemyHealth != null)
            //{
            //    enemyHealth.TakeDamage(damagePerShot, shootHit.point);
            //}
            gunLine.SetPosition(1, shootHit.point);
        }
        else
        {
            // "1"indica la posicion al igual q shootray. Se dispara de todas maneras en caso de no dar con el objetivo
            gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
        }
    }
}
