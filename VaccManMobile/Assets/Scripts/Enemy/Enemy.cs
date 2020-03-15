using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int health = 1;

    private MeeleEnemy meeleEnemy;
    private Animator animator;
    [SerializeField]
    private ParticleSystem ps_Dying;

    // Start is called before the first frame update
    void Start()
    {
        meeleEnemy = GetComponent<MeeleEnemy>();
    }

    // Update is called once per frame
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
        Debug.Log("get Hit with " + dmg);

        if(health > 0)
        health -= dmg;
    }

    void Die()
    {
        //animator.SetBool("isAlive", false);
        //ps_Dying.Play();
        meeleEnemy.MyMoveAble = false;
        Destroy(gameObject);
    }

}
