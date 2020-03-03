using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPref;
    public float bulletForce = 20f;

    [SerializeField]
    private Transform aimTransform;
    Vector3 mousePos;

    void Update()
    {
       
        Aim();

        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPref, aimTransform.position, aimTransform.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(aimTransform.right * bulletForce,ForceMode2D.Impulse);
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

    // void OnCollisionEnter2D(Collider2D other)
    // {
    //     if(other.CompareTag("Player"))
    //     {
    //         return;
    //     }
    //     else
    //     {
    //         //apply dmg to object

    //         //play particle effect

    //         //destroy this
    //         //Destroy(this);
    //         Debug.Log("Hit " + other.name);
    //     }
    // }
}
