using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeeleEnemy : MonoBehaviour
{
    public GameObject target;
    private Player player;

    // --- seek and follow player ---
    [Header("Movement")]
    private Vector2 movement;
    [SerializeField] private float speed = .8f;
    bool moveAble = true;

    public bool MyMoveAble
    {
        set { moveAble = value;}
    }

    float dist = Mathf.Infinity;                        // to calculate distance to player and stop when near to him

    private bool seekPlayer = true;
    public bool MySeekPlayer
    {
        set {seekPlayer = value;}
    }

    // --- attack ---
    [Header("Attack related")]
    [SerializeField] float attackRange = .9f;
    [SerializeField] float attackSpeed = 2.0f;
    [SerializeField] int damage = 1;
    private float attackCooldown;

    // --- animations & effects ---
    [SerializeField] private Animator animator;
    

    void Start()
    {
        //maybe null pointer abfangen
        target = GameObject.FindGameObjectWithTag("Player");
        player = target.GetComponent<Player>();
        // animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(moveAble) MoveTo();
    }


    void MoveTo()
    {   
        // calculate Distance to target
        dist = Vector2.Distance(this.transform.position, target.transform.position);
                
        // animation enable

        //move to
        if(seekPlayer && dist > attackRange)
        {
            movement = Vector2.MoveTowards(this.transform.position, target.transform.position, speed * Time.deltaTime);
            this.transform.position = movement;
        }
        else if(dist <= attackRange)
        {
            Attack();
        }

    }

    void Attack()
    {
        // animator.SetBool("isAttacking", true);
        attackCooldown -= Time.deltaTime;
        if(attackCooldown <= 0.0f)
        {
            attackCooldown = attackSpeed;
            player.GetHit(damage);
        }
    }
}
