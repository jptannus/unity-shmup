using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengeSpawner : MonoBehaviour
{
    public GameObject challenge01;
    // Start is called before the first frame update
    void Start()
    {
        if (challenge01) {
            Instantiate(challenge01, this.transform.position, Quaternion.identity, this.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
