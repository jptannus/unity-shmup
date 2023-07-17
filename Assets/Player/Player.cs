using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 8;
    public GameObject bulletPrefab;
    public float delayBetweenShots = 0.3f;
    private bool isShooting = false;
    private float shootingDelay = 0;
    private const float SHOOTER_Y = 0.1f;
    private const float SHOOTER_X = 0.45f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePosition(this.speed * Time.deltaTime);
        UpdateShooting(Time.deltaTime);
    }

    private void UpdatePosition(float multiplier)
    {
        float h = 0;
        if(Input.GetButton("Horizontal")) 
        {
            h = Input.GetAxis("Horizontal");
        }

        float v = 0;
        if(Input.GetButton("Vertical")) 
        {
            v = Input.GetAxis("Vertical");
        }
        Vector3 tempVect = new Vector3(h, v, 0);
        tempVect = tempVect.normalized * multiplier;

        this.transform.position += tempVect;
    }

    private void UpdateShooting(float deltaTime) 
    {
        if (this.isShooting)
        {
            if (this.shootingDelay < this.delayBetweenShots)
            {
                this.shootingDelay += deltaTime;
            }
            else
            {
                this.isShooting = false;
                this.shootingDelay = 0;
            }
        } 
        else if(Input.GetButton("Fire1"))
        {
            this.isShooting = true;
            Shoot();
        }
    }

    private void Shoot()
    {
        if (this.bulletPrefab) {
            CreateBulletLeftShooter();
            CreateBulletRightShooter();
        }
    }

    private void CreateBulletLeftShooter()
    {
        Vector3 position = this.transform.position;
        position.x -= SHOOTER_X;
        position.y += SHOOTER_Y;
        CreateBullet(position);
    }
    private void CreateBulletRightShooter()
    {
        Vector3 position = this.transform.position;
        position.x += SHOOTER_X;
        position.y += SHOOTER_Y;
        CreateBullet(position);
    }

    private void CreateBullet(Vector3 position)
    {
        Instantiate(bulletPrefab, position, Quaternion.identity);
    }
}
