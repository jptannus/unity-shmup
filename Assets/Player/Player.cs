using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 8;
    public GameObject bulletPrefab;
    public float delayBetweenShots = 0.3f;
    bool isShooting = false;
    float shootingDelay = 0;
    const float SHOOTER_Y = 0.1f;
    const float SHOOTER_X = 0.45f;
    int maxLife = 3;
    int currentLife;
    public LifeCounter lifeCounter;
    const float X_BOUNDARY = 3.14f;
    const float Y_BOUNDARY = 4.39f;

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

    void UpdatePosition(float multiplier)
    {
        float h = this.GetHorizontalMoviment();
        float v = this.GetVerticalMoviment();
        Vector3 tempVect = new Vector3(h, v, 0);
        tempVect = tempVect.normalized * multiplier;

        this.transform.position += tempVect;
    }

    float GetHorizontalMoviment()
    {
        float h = 0;
        if(Input.GetButton("Horizontal")) 
        {
            float axis = Input.GetAxis("Horizontal");
            float currentX = this.transform.position.x;
            if ((axis > 0 && currentX < X_BOUNDARY) || (axis < 0 && currentX > -X_BOUNDARY))
            {
                h = axis;
            }
        }
        return h;
    }

    float GetVerticalMoviment()
    {
        float v = 0;
        if(Input.GetButton("Vertical")) 
        {
            float axis = Input.GetAxis("Vertical");
            float currentY = this.transform.position.y;
            if ((axis > 0 && currentY < Y_BOUNDARY) || (axis < 0 && currentY > -Y_BOUNDARY))
            {
                v = axis;
            }
        }
        return v;
    }

    void UpdateShooting(float deltaTime) 
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

    void Shoot()
    {
        if (this.bulletPrefab) {
            this.CreateBulletLeftShooter();
            this.CreateBulletRightShooter();
        }
    }

    void CreateBulletLeftShooter()
    {
        Vector3 position = this.transform.position;
        position.x -= SHOOTER_X;
        position.y += SHOOTER_Y;
        this.CreateBullet(position);
    }
    void CreateBulletRightShooter()
    {
        Vector3 position = this.transform.position;
        position.x += SHOOTER_X;
        position.y += SHOOTER_Y;
        this.CreateBullet(position);
    }

    void CreateBullet(Vector3 position)
    {
        Instantiate(bulletPrefab, position, Quaternion.identity);
    }

    void FillHeath() => this.currentLife = this.maxLife;
    void ReduceHealth()
    {
        this.currentLife--;
        lifeCounter.SetValue(this.currentLife);
        if (this.currentLife <= 0)
        {
            this.SelfDestroy();
        }
    }
    void GainHealth()
    {
        if (this.currentLife < this.maxLife)
        {
            this.currentLife++;
            lifeCounter.SetValue(this.currentLife);
        }
    }

    void SelfDestroy() => Destroy(this.gameObject);

    void OnTriggerEnter2D(Collider2D collider) 
    {
        if (collider.tag is "EnemyBullet") 
        {
            this.ReduceHealth();
        }
    }
}
