using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
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

    ///<summary> get and set healthvalue of player </summary>
    public int MyHealth
    {
        get{ return health;}
        set{ health = value;}
    }

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

        if(Input.GetButtonDown("test"))
        {
            Die();
            //health -= 1;
        }
    }

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
    }

}
