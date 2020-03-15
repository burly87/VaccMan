using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator animator;
    [SerializeField]
    private GameObject mask, eyes;                  // at the moment ok. but bad to just deactivate gameobject. should be done in animator

    [SerializeField]
    private int health = 3;

    private PlayerMovement playerMovement;

    // --- effects ----
    [SerializeField]
    private ParticleSystem ps_Dying;
    // ---------

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        animator = GetComponentInChildren<Animator>();  
    }
    void Update()
    {
        if(health <= 0) 
        {
            health = 0;
            Die();
        }
    }

    public void GetHit(int dmg)
    {
        if(health >0)
        health -= dmg;
    }

    ///<summary>Player die</summary>
    void Die()
    {   
        // Display UI element that you are dead
        // play death animation
        animator.SetBool("isAlive", false);
        mask.SetActive(false);
        eyes.SetActive(false);
        // spawn splatter particle
        ps_Dying.Play();
        // shut down movement
        playerMovement.MyMoveAble = false;

        // DISABLE EVERYTHING
    }

}
