using UnityEngine;

[CreateAssetMenu(fileName = "Projectile", menuName = "ScriptableObjects/Projectile", order = 1)]
public class Projectile_SO : ScriptableObject
{
    // --- stats ---
    public string projectileName;
    public float damage;
    public float cooldown;
    public float speed;

    // --- effects ---
    // public SpriteRenderer sprite;
    // public ParticleSystem ps_muzzleFlash;
    // public ParticleSystem ps_onHit;

    // --- instantiate ---
    public GameObject prefab;
}
