using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public const float SPEED = 8;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMoviment(SPEED * Time.deltaTime);
    }

    private void UpdateMoviment(float speed) {
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
        tempVect = tempVect.normalized * speed;

        this.transform.position += tempVect;
    }
}
