using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCounter : MonoBehaviour
{
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
    void Disable(Transform heart)
    {
        if (heart) {
            heart.gameObject.SetActive(false);
        }
    }
    void Enable(Transform heart)
    {
        if (heart) {
            heart.gameObject.SetActive(true);
        }
    }
}
