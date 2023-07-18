using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedEnemy : MonoBehaviour
{
    public float delayBetweenShots = 1.0f;
    bool isShooting = false;
    float shootingDelay = 0;
    public GameObject bulletPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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

    void OnTriggerEnter2D(Collider2D collider) 
    {
        if (collider.tag is "PlayerBullet") 
        {
            this.OnShot();
        }
    }

    void OnShot()
    {
        Destroy(this.gameObject);
    }

    void ShootBullet()
    {
        Instantiate(bulletPrefab, this.transform.position, Quaternion.identity);
    }
}
