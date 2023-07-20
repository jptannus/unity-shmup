using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootRedBullets : MonoBehaviour
{
    
    bool isShooting = false;
    float shootingDelay = 0;
    [SerializeField]
    float delayBetweenShots = 1.0f;
    [SerializeField]
    bool shouldShoot = true;
    [SerializeField]
    GameObject bulletPrefab;
    [SerializeField]
    int numberOfBullets = 1;
    [SerializeField]
    float paddingBetweenBullets = 0.1f;
    [SerializeField]
    Vector2 bulletOffset = new Vector2(0,0);
    [SerializeField]
    float bulletWidth = 0.2f;

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
            this.ShootBullets();
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

    void ShootBullets()
    {
        float totalBulletWidth = this.bulletWidth * this.numberOfBullets;
        float totalBulletPadding = this.paddingBetweenBullets * (this.numberOfBullets - 1);
        float totalWidth = totalBulletWidth + totalBulletPadding;
        float startXOffset = this.bulletWidth/2;
        float startX = this.transform.position.x - totalWidth/2 + startXOffset;
        float distanceBetweenBullets = this.bulletWidth + this.paddingBetweenBullets;

        for(int i = 0; i < this.numberOfBullets; i++)
        {
            Vector3 position = this.transform.position;
            position.x = startX + i * distanceBetweenBullets + this.bulletOffset.x;
            position.y += this.bulletOffset.y;
            Instantiate(bulletPrefab, position, Quaternion.identity);
        }
    }
    
}
