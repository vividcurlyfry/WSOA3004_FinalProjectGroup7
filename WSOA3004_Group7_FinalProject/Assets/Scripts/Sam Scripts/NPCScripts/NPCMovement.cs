using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCMovement : MonoBehaviour
{
    public GameObject destination;
    public float minutes;
    public bool talking = false, isRaining = false;
    public Animator anim;

    private Vector3 nextPosition, home, middle;
    [SerializeField]
    private float speed = 2f;
    private float pause = 0, setPause, t = 0;
    [SerializeField]
    private bool isPaused = false, dayOver = false, goHome = false, returnFromIdleTalk = false;
    private int today = 0;

    private void Start()
    {
        minutes = GameObject.FindGameObjectWithTag("GameManager").GetComponent<TimerScript>().MinutesInDay;
        minutes = minutes * 60;

        nextPosition = new Vector3(destination.transform.position.x, destination.transform.position.y, destination.transform.position.z);

        home = new Vector3(17.69f, 16f, -1);
        middle = new Vector3(3.5f, 7, -1);

        today = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>().DaysPlayed;
        //print(today);
        isRaining = GameObject.FindGameObjectWithTag("GameManager").GetComponent<LivelinessEffects>().Raining;

        //these times work for 15 minute day //update if day time changes
        if (isRaining)
        {
            setPause = 225;
        }
        else if ((today == 0)|| (today == 3))
        {
            setPause = 2;
        }
        else if ((today == 1)|| (today == 4))
        {
            setPause = 4;
        }
        else if ((today == 2)|| (today == 5))
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
                if (this.transform.position == nextPosition)
                {
                    pause += Time.deltaTime;
                    isPaused = true;
                    updateAnimation();
                }

                if (pause > setPause)
                {
                    nextPosition = new Vector3(destination.transform.position.x, destination.transform.position.y, destination.transform.position.z);
                    pause = 0;
                    isPaused = false;
                    updateAnimation();
                }
            }
            else if (!goHome)
            {
                isPaused = false;
                nextPosition = middle;
                updateAnimation();
            }

            if (goHome)
            {
                isPaused = false;
                nextPosition = home;
                updateAnimation();
            }

            if(returnFromIdleTalk)
            {
                returnFromIdleTalk = false;
                updateAnimation();
            }

            this.transform.position = Vector3.MoveTowards(this.transform.position, nextPosition, speed * Time.deltaTime);
        }

        if(talking)
        {
            updateAnimation();
        }
    }

    public void updateAnimation()
    {
        if (talking)
        {
            anim.Play("RubyIdle");
           // print("idle");
            returnFromIdleTalk = true;
        }
        else
        {
            if (!isPaused)
            {
                if ((Mathf.Abs(Mathf.Abs(nextPosition.y) - Mathf.Abs(this.transform.position.y))) > (Mathf.Abs(Mathf.Abs(nextPosition.x) - Mathf.Abs(this.transform.position.x))))
                {
                    if (nextPosition.y < this.transform.position.y)
                    {
                        anim.Play("WalkingFrontRuby");
                       // print("face forward");
                    }
                    else if (nextPosition.y > this.transform.position.y)
                    {
                        anim.Play("WalkingBackRuby");
                       // print("backward");
                    }
                }
                else
                {
                    if (nextPosition.x < this.transform.position.x)
                    {
                        anim.Play("WalkingLeftRuby");
                      //  print("left");
                    }
                    else if (nextPosition.x > this.transform.position.x)
                    {
                        anim.Play("WalkingRightRuby");
                      //  print("right");
                    }
                }
            }

            if ((isPaused)&&(!dayOver))
            {
                anim.Play("RubyIdle");
               // print("idle");
            }
        }
        
    }
}
