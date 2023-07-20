using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCanHit : MonoBehaviour
{
    int currentLife;
    [SerializeField]
    int maxLife = 1;
    [SerializeField]
    public bool isInvencible = false;
    void Start()
    {
        this.currentLife = maxLife;
    }
    void OnTriggerEnter2D(Collider2D collider) 
    {
        if (collider.tag is "PlayerBullet") 
        {
            if (!this.isInvencible)
            {
                this.LoseLife();
            }
        }
    }

    void LoseLife()
    {
        this.currentLife--;
        if (this.currentLife <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
