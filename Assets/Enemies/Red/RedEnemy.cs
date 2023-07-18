using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedEnemy : MonoBehaviour
{
    public float delayBetweenShots = 1.0f;
    bool isShooting = false;
    float shootingDelay = 0;
    public bool shouldShoot = true;
    public GameObject bulletPrefab;
    const float X_BOUNDARY = 3.14f;
    public float speed = 3;
    int moveDirection = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.UpdateShooting(Time.deltaTime);
        this.UpdatePosition(Time.deltaTime);
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

    void UpdatePosition(float deltaTime)
    {
        float currentX = this.transform.position.x;
        if (this.moveDirection > 0 && currentX >= X_BOUNDARY)
        {
            this.moveDirection = -1;
        }
        else if(this.moveDirection < 0 && currentX <= -X_BOUNDARY)
        {
            this.moveDirection = 1;
        }
        Vector3 tempVect = new Vector3(moveDirection, 0, 0);
        tempVect = tempVect.normalized * speed * deltaTime;

        this.transform.position += tempVect;
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
        if(this.shouldShoot) 
        {
            Instantiate(bulletPrefab, this.transform.position, Quaternion.identity);
        }
    }
}
