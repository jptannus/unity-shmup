using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MovementOptions
{
    LeftToRight,
    LeftToHalf,
    HalfToRight
}

public class MoveLeftToRight : MonoBehaviour
{
    const float SCREEN_X_LIMIT = 3.14f;
    public float speed = 3;
    int moveDirection = 1;
    public bool shouldMove = true;
    public MovementOptions movementStyle; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.shouldMove)
        {
            this.UpdatePosition(Time.deltaTime);
        }
    }

    void UpdatePosition(float deltaTime)
    {
        float currentX = this.transform.position.x;
        if (this.moveDirection > 0 && currentX >= this.GetRightXLimit())
        {
            this.moveDirection = -1;
        }
        else if(this.moveDirection < 0 && currentX <= this.GetLeftXLimit())
        {
            this.moveDirection = 1;
        }
        Vector3 tempVect = new Vector3(moveDirection, 0, 0);
        tempVect = tempVect.normalized * speed * deltaTime;

        this.transform.position += tempVect;
    }

    float GetLeftXLimit() 
    {
        if(this.movementStyle == MovementOptions.LeftToRight ||
           this.movementStyle == MovementOptions.LeftToHalf) 
        {
            return -SCREEN_X_LIMIT;
        }
        return 0;
    }
    float GetRightXLimit() 
    {
        if(this.movementStyle == MovementOptions.LeftToRight ||
           this.movementStyle == MovementOptions.HalfToRight) 
        {
            return SCREEN_X_LIMIT;
        }
        return 0;
    }
}
