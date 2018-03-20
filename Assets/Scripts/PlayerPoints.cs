using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPoints : MonoBehaviour {

    //** Point se usara en referencia de Health (o simbolo de Energy (rayo = vidas, etc))

    public int startingPoint = 100;
    public int currentPoint;

    //Cambiar slider por numeros en un TextMesh
    public SliderJoint2D healthSlider;
  
    //Añadir imagen de daño(Deshabilitada por ahora: necesita un tipo HUD -> Canvas)
    //public Image damageImage;
    //Añadir AudioSource al player para simular Daño
    //public AudioClip deathClip;
    //Velocidad con que se aplica el Image damageImage
    //public float flashSpeed = 5f;
    //public Color flashColour = new Color(1f, 0f, 0f, 0.1f);

    //Privates Variables
    //Player movement dehabilitado porque se usa OVRController
    //PlayerMovement playerMovement;
    //PlayerShooting playerShooting;
    bool isDead;
    bool damaged;

	void Awake ()
    {
        //playerMovement = GetComponent<PLayerMovement>();
        //playerShooting = GetComponentInChild<PLayerShooting>();
        currentPoint = startingPoint;
    }

    void Update ()
    {
        //Animacion pantalla daño Deshabilitada
        //if (damaged)
        //{
        //    damageImage.color = flashColour;
        //}
        //else
        //{
        //    damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed);
        //}
        //damaged = false;

	}

    //Nombre de clase LosePoints -> TakeDamage
    public void LosePoints(int amount)
    {
        //damaged se usa para arriba habilitar la animacion de daño(pantalla roja)
        damaged = true;
        currentPoint -= amount;

        //HAbilitar en caso de usar SlideBar para las vidas
        //healthSlider.value = currentPoint;

        if (currentPoint <= 0 && !isDead)
        {
            //Si llego a 0 el jugador muere
            //Death();
        }

    }

    void Death()
    {
        isDead = true;

        //En caso de tener los efectos activar este codigo
        //PlayerShooting.DisableEffects();

        //No se tiene animacion o cambio de estado de Animator a muerto.
        //anim.SetTrigger("Die");

        //Añadir una especie de  clip animacion de Game over o muerte.

        //No se utiliza movimiento (solo teleport or rotation)
        //playerMovement.enabled = false;
        //PLayer shooting effect stopping
        //playerShooting.enable = false;

    }

}
