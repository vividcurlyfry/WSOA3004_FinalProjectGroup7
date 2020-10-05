using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCMovement : MonoBehaviour
{
    public GameObject destination;
    public float minutes;
    public bool talking = false, isRaining = false;

    private Vector3 nextPosition, home, middle;
    [SerializeField]
    private float speed = 2f;
    private float pause = 0, setPause, t = 0;
    private bool isPaused = false, dayOver = false, goHome = false;
    private int today = 3;

    private void Start()
    {
        minutes = GameObject.FindGameObjectWithTag("GameManager").GetComponent<TimerScript>().MinutesInDay;
        minutes = minutes * 60;

        nextPosition = new Vector3(destination.transform.position.x, destination.transform.position.y, destination.transform.position.z);

        home = new Vector3(17, 17, -1);
        middle = new Vector3(3.5f, 7, -1);

        //today = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>().Today; //Amy needs to add this connection
        isRaining = GameObject.FindGameObjectWithTag("GameManager").GetComponent<LivelinessEffects>().Raining;

        //these times work for 15 minute day //update if day time changes
        if (isRaining)
        {
            setPause = 225;
        }
        else if (today == 1)
        {
            setPause = 2;
        }
        else if (today == 2)
        {
            setPause = 4;
        }
        else if (today == 3)
        {
            setPause = 225;
        }
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;

        
            if (t > (0.8 * minutes))
            {
                dayOver = true;
            }

            if (t > (0.9 * minutes))
            {
                goHome = true;
            }

            if (this.transform.position == home)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sortingOrder = -1;
            }
            else
            {
                this.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 9;
            }

        if (!talking)
        {
            if (!dayOver)
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
            }
            else if (!goHome)
            {
                this.transform.position = Vector3.MoveTowards(this.transform.position, middle, speed * Time.deltaTime);
            }

            if (goHome)
            {
                this.transform.position = Vector3.MoveTowards(this.transform.position, home, speed * Time.deltaTime);
            }

            updateAnimation(); //check this placement, might be more dynamic for Rubys movement, might look sus? Could put in if where next is set and if when paused instead??
        }
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
