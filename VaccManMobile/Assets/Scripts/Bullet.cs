using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem ps_explosion;

    private Projectile_SO projectile_;

    void OnTriggerEnter2D(Collider2D other)
    {
        ParticleSystem temp = Instantiate(ps_explosion,transform.position, Quaternion.identity);
        if(other.tag == "Player")
        {
           // return;
        }
        if(other.tag == "Enemy")
        {
            //apply dmg

        }
        temp.Play();
        Destroy(temp,3f);
        Destroy(gameObject);
    }
}
