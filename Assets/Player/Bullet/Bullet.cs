using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script : MonoBehaviour
{
    public float speed = 14;

    private const int Y_THRESHOLD = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 tempVect = new Vector3(0, 1, 0) * speed * Time.deltaTime;
        this.transform.position += tempVect;

        if (this.transform.position.y > Y_THRESHOLD)
        {
            Destroy(this.gameObject);
        }
    }
}
