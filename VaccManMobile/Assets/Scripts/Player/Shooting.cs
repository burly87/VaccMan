using UnityEngine;

public class Shooting : MonoBehaviour
{
    [Header("shooting")]    
    Projectile projectileToSpawn;
    public Projectile[] skills;                 // Debug Array with different Projectiles
    private float currentCD = 0.0f;

    [Header("aiming")]
    [SerializeField]
    private Transform aimTransform;
    Vector3 mousePos;

    [Header("effects")]
    [SerializeField]
    private ParticleSystem ps_muzzleFlash;

    void Start()
    {
        projectileToSpawn = skills[0];
    }

    void Update()
    {
        Aim();

        if(Input.GetButtonDown("Fire1") && currentCD <= 0.0f)
        {
            currentCD = projectileToSpawn.cooldown;
            Shoot();
        }
        currentCD -= Time.deltaTime;

        // Debug only 
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            projectileToSpawn = skills[0];
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            projectileToSpawn = skills[1];
        }
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            projectileToSpawn = skills[2];
        }
    }

    void Shoot()
    {  
        Projectile projectile = Instantiate(projectileToSpawn, aimTransform.position, aimTransform.rotation);
        projectile.GetComponent<Rigidbody2D>().AddForce(aimTransform.right * projectileToSpawn.speed, ForceMode2D.Impulse);
        ps_muzzleFlash.Play();
    }

    // Get Mouseposition, calculate direction vector and rotate the aimTransformObject in that direction
    void Aim()
    {
        //get mousPos and rotate aimTransform
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 lookDir = (mousePos - this.transform.position).normalized;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0,0,angle);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hit " + other.name);

        if(other.gameObject.tag == "Enemy")
        {
            Debug.Log("test");
        }
        else
        {
            //apply dmg to object

            //play particle effect

            //destroy this
            //Destroy(this);
            Debug.Log("Hit " + other.gameObject.name);
        }
    }
}
