using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCounter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetValue(int value)
    {
        for(int i = 0; i < this.transform.childCount; i++)
        {
            if(i < value)
            {
                Enable(this.transform.GetChild(i));
            }
            else
            {
                Disable(this.transform.GetChild(i));
            }
        }
    }
    private void Disable(Transform heart)
    {
        if (heart) {
            heart.gameObject.SetActive(false);
        }
    }
    private void Enable(Transform heart)
    {
        if (heart) {
            heart.gameObject.SetActive(true);
        }
    }
}
