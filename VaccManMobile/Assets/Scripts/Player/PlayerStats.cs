using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    [SerializeField]
    private int health = 3;

    private PlayerMovement playerMovement;
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
    }
    void Update()
    {
        if(health <= 0) 
        {
            health = 0;
            Die();
        }
    }

    void Die()
    {   
        // Display UI element that you are dead
        // play death animation
        // spawn splatter particle
        // shut down movement
        playerMovement.MyMoveAble = false;
    }

}
