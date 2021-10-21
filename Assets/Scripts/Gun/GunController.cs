using UnityEngine;

public class GunController : MonoBehaviour
{
    enum WeaponType
    {
        Pistol,
        Shotgun,
        Rifle
    }

    [Header("Gun")]
    [SerializeField] WeaponType type;
    [SerializeField] BulletController bullet;
    [SerializeField] float bulletSpeed;
    [SerializeField] float timeBetweenShots;
    [SerializeField] Transform firePoint;


    float shotCounter;
    public bool isFiring;

    private void Start()
    {
        shotCounter = 0;
    }
    private void Update()
    {
        HandleShotCounter();
        HandleFiring();
    }

    void HandleShotCounter()
    {
        if (shotCounter > 0)
            shotCounter -= Time.deltaTime;
    }
    void HandleFiring()
    {
        if (isFiring)
        {
            if (shotCounter <= 0)
            {
                shotCounter = timeBetweenShots;
                BulletController newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as BulletController;
                newBullet.speed = bulletSpeed;
            }
        }
    }
}
