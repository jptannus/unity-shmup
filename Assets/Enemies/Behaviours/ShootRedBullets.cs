using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootRedBullets : MonoBehaviour
{
    
    public float delayBetweenShots = 1.0f;
    bool isShooting = false;
    float shootingDelay = 0;
    public bool shouldShoot = true;
    public GameObject bulletPrefab;

    // Update is called once per frame
    void Update()
    {
        if (this.shouldShoot)
        {
            this.UpdateShooting(Time.deltaTime);
        }
    }

    void UpdateShooting(float deltaTime)
    {
        if (!this.isShooting)
        {
            this.isShooting = true;
            this.ShootBullet();
        }
        else if (shootingDelay >= delayBetweenShots) 
        {
            this.isShooting = false;
            shootingDelay = 0;
        }
        else
        {
            shootingDelay += Time.deltaTime;
        }
    }

    void ShootBullet()
    {
        Instantiate(bulletPrefab, this.transform.position, Quaternion.identity);
    }
}
