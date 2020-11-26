using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCMovement : MonoBehaviour
{
    public GameObject destination, rubyHungry, rubyHeart;
    public float minutes;
    public bool talking = false, isRaining = false;
    public Animator anim;

    private Vector3 nextPosition, home, middle;
    [SerializeField]
    private float speed = 2f;
    private float pause = 0, setPause, t = 0;
    [SerializeField]
    private bool isPaused = false, dayOver = false, goHome = false, returnFromIdleTalk = false;

    private void Start()
    {
        minutes = GameObject.FindGameObjectWithTag("GameManager").GetComponent<TimerScript>().MinutesInDay;
        minutes = minutes * 60;

        nextPosition = new Vector3(destination.transform.position.x, destination.transform.position.y, destination.transform.position.z);

        home = new Vector3(17.69f, 16f, -1);
        middle = new Vector3(3.5f, 7, -1);

        Debug.Log("Ruby today " + GameManagerScript.instance.RubyLoop);
        //print(today);
        isRaining = GameObject.FindGameObjectWithTag("GameManager").GetComponent<LivelinessEffects>().Raining;

        //these times work for 10 minute day
        if (isRaining)
        {
            setPause = 150; //(quarter of total time)
        }
        else if (GameManagerScript.instance.RubyLoop == 0)
        {
            setPause = 60;
        }
        else if (GameManagerScript.instance.RubyLoop == 1)
        {
            setPause = 35;
        }
        else if (GameManagerScript.instance.RubyLoop == 2)
        {
            setPause = 120;
        }
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;

        
            if (t > (0.75 * minutes))
            {
                dayOver = true;
            }

            if (t > (0.755 * minutes))
            {
                goHome = true;
            }

            if (this.transform.position == home)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sortingOrder = -1;
                rubyHungry.gameObject.GetComponent<SpriteRenderer>().sortingOrder = -1;
                rubyHeart.SetActive(false);
            }
            else
            {
                this.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 9;
                rubyHungry.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 9;
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
