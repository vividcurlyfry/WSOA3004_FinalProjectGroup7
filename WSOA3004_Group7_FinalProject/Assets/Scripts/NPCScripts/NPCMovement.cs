using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCMovement : MonoBehaviour
{
    public GameObject destination;

    private Vector3 nextPosition, home;
    [SerializeField]
    private float speed = 1;
    private float pause = 0;
    private float setPause = 2;
    private bool isPaused = false;

    private void Start()
    {
        nextPosition = new Vector3(destination.transform.position.x, destination.transform.position.y, destination.transform.position.z);

        home = new Vector3(20, 16, -1);

        //if Day 1 set setPause to x - need a class to keep track of day cycles
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, nextPosition, speed * Time.deltaTime);

        if (this.transform.position == nextPosition)
        {
            pause += Time.deltaTime;
            isPaused = true;
        }

        if (pause > setPause)
        {
            nextPosition = new Vector3(destination.transform.position.x, destination.transform.position.y, destination.transform.position.z);
            pause = 0;
            isPaused = false;
        }

        if (this.transform.position == home)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sortingOrder = -1;
        }
        else
        {
            this.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 20;
        }

        updateAnimation(); //check this placement, might be more dynamic for Rubys movement, might look sus? Could put in if where next is set and if when paused instead??
    }

    public void updateAnimation()
    {
        if (!isPaused)
        {
            if((Mathf.Abs(Mathf.Abs(nextPosition.y) - Mathf.Abs(this.transform.position.y))) > (Mathf.Abs(Mathf.Abs(nextPosition.x) - Mathf.Abs(this.transform.position.x))))
            {
                if (nextPosition.y < this.transform.position.y)
                {
                    //trigger face up animation
                    print("face forward");
                }
                else if (nextPosition.y > this.transform.position.y)
                {
                    //trigger back animation
                    print("backward");
                }
            }
            else
            {
                if (nextPosition.x < this.transform.position.x)
                {
                    //trigger left animation
                    print("left");
                }
                else if (nextPosition.x > this.transform.position.x)
                {
                    //trigger right animation
                    print("right");
                }
            }
        }
        else
        {
            //idle animation
            print("idle");
        }
    }
}
