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
    private int maxLife = 3;
    private int currentLife;
    public LifeCounter lifeCounter;

    // Start is called before the first frame update
    void Start()
    {
        this.FillHeath();
    }

    // Update is called once per frame
    void Update()
    {
        this.UpdatePosition(this.speed * Time.deltaTime);
        this.UpdateShooting(Time.deltaTime);
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
            this.Shoot();
        }
    }

    private void Shoot()
    {
        if (this.bulletPrefab) {
            this.CreateBulletLeftShooter();
            this.CreateBulletRightShooter();
        }
    }

    private void CreateBulletLeftShooter()
    {
        Vector3 position = this.transform.position;
        position.x -= SHOOTER_X;
        position.y += SHOOTER_Y;
        this.CreateBullet(position);
    }
    private void CreateBulletRightShooter()
    {
        Vector3 position = this.transform.position;
        position.x += SHOOTER_X;
        position.y += SHOOTER_Y;
        this.CreateBullet(position);
    }

    private void CreateBullet(Vector3 position)
    {
        Instantiate(bulletPrefab, position, Quaternion.identity);
    }

    private void FillHeath() => this.currentLife = this.maxLife;
    private void ReduceHealth()
    {
        this.currentLife--;
        lifeCounter.SetValue(this.currentLife);
        if (this.currentLife <= 0)
        {
            this.SelfDestroy();
        }
    }
    private void GainHealth()
    {
        if (this.currentLife < this.maxLife)
        {
            this.currentLife++;
            lifeCounter.SetValue(this.currentLife);
        }
    }

    private void SelfDestroy() => Destroy(this.gameObject);
}
