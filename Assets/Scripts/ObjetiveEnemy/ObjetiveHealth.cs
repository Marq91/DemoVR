using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//**Script ObjetiveHealth = EnemyHealth
public class ObjetiveHealth : MonoBehaviour {

    public int startingHealth = 100;            //vida inicial con la que conmienza.
    public int currentHealth;                   //vida actual del enemigo.
    //public float sinkSpeed = 2.5f;              // Velocidad con que el enemigo se unde en el piso.
    public int scoreValue = 10;                 // The amount added to the player's score when the enemy dies.
    public AudioClip deathClip;                 //el sonido se ejecuta cuando el objetivo explota.

    //Animator anim;                              // Reference to the animator.
    AudioSource enemyAudio;                     // Reference to the audio source.
    //CapsuleCollider capsuleCollider;            // Reference to the capsule collider, Para dejar de tener presencia fisica en el escenario.
    bool isDead;                                // Whether the enemy is dead.
    //bool isSinking;                             //Indica si el enemigo tiene undirse en el suelo.
    
    void Awake()
    {
        //anim = GetComponent<Animator>();
        enemyAudio = GetComponent<AudioSource>();
        
        //capsuleCollider = GetComponent<CapsuleCollider>();
        
        currentHealth = startingHealth;
    }
    
    void Update()
    {
        // si el enemigo se debe undir...
        //if (isSinking)
        //{
        //    // ... move the enemy down by the sinkSpeed per second.
        //    transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
        //}
    }

    //amount= cantidad de daño. /quiza se deba quitar hitPoint ya que solo es para el efecto de particulas de recibir daño
    public void TakeDamage(int amount, Vector3 hitPoint)
    {
        // If the enemy is dead...
        if (isDead)
            //...no need to take damage (no necesitamos hacer nada si el enemy esta muerto).
            return;

        // Play the "hurt" sound effect.
        enemyAudio.Play();

        // Reduce the current health by the amount of damage sustained.
        currentHealth -= amount;

        // Set the position of the particle system to where the hit was sustained.
        //hitParticles.transform.position = hitPoint;

        // And play the particles.
        //hitParticles.Play();

        // If the current health is less than or equal to zero...
        if (currentHealth <= 0)
        {
            // ... the enemy is dead.
            Death();
        }
    }
    
    void Death()
    {
        // The enemy is dead.
        isDead = true;

        // Turn the collider into a trigger so shots can pass through it.
        //capsuleCollider.isTrigger = true;

        //Tell the animator controller que el enemigo esta muerto y ejecutar el estado muerto que reproducira la animacion de explosion.
        //anim.SetTrigger("Dead");

        // Change the audio clip of the audio source to the death clip and play it (this will stop the hurt clip playing).
        enemyAudio.clip = deathClip;
        enemyAudio.Play();
    }

    public void StartSinking()
    {
        // Find and disable the Nav Mesh Agent.
        //GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;

        // Find the rigidbody component and make it kinematic (since we use Translate to sink the enemy).
        //GetComponent<Rigidbody>().isKinematic = true;

        // The enemy should no sink.
        //isSinking = true;

        // Incrementar el score
        ScoreManager.score += scoreValue;

        //Destuir al enemigo despuse de 2 segundos
        Destroy(gameObject, 2f);
    }

}
