using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBullet : MonoBehaviour
{
    public float speed = 12;
    const int Y_THRESHOLD = -10;

    // Update is called once per frame
    void Update()
    {
        Vector3 tempVect = new Vector3(0, 1, 0) * speed * Time.deltaTime;
        this.transform.position -= tempVect;

        if (this.transform.position.y < Y_THRESHOLD)
        {
            this.SelfDestroy();
        }
    }

    void OnTriggerEnter2D(Collider2D collider) 
    {
        if (collider.tag is "Player")
        {
            this.SelfDestroy();
        }
    }

    void SelfDestroy()
    {
        Destroy(this.gameObject);
    }
}
