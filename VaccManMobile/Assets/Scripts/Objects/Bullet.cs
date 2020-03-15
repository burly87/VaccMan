using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private ParticleSystem ps_explosion;

    // --- stats ---
    public int damage;
    public float cooldown;
    public float speed;

    // --- effects ---
    // public SpriteRenderer sprite;
    // public ParticleSystem ps_muzzleFlash;
    // public ParticleSystem ps_onHit;

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
            other.GetComponent<Enemy>().GetHit(damage);
        }
        temp.Play();
        Destroy(temp,3f);
        Destroy(gameObject);
    }
}
