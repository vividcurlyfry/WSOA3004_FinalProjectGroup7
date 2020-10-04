using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCPath : MonoBehaviour
{
    public int position = 0;
    public bool isRaining = false;

    private Vector3 _FirstPos, _SecondPos, _ThirdPos;

    private int today = 3;

    ////////////// NOTE ////////////////
    //Day 1: Hanging on the farm
    //Day 2: Beekeeping
    //Day 3: Going to town
    ////////////////////////////////////
   

    private void Start()
    {
        //today = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>().Today; //Amy needs to add this connection
        isRaining = GameObject.FindGameObjectWithTag("GameManager").GetComponent<LivelinessEffects>().Raining;
        if (isRaining)
        {
            _FirstPos = new Vector3(10f, 15.5f, -1);
            _SecondPos = new Vector3(7f, 15.5f, -1);
            _ThirdPos = new Vector3(5.5f, 15.5f, -1);
        }
        else if (today == 1)
        {
            _FirstPos = new Vector3(19, 15, -1);
            _SecondPos = new Vector3(0, 15, -1);
            _ThirdPos = new Vector3(5.5f, 15.5f, -1);
        }
        else if (today == 2)
        {
            _FirstPos = new Vector3(4f, 2, -1);
            _SecondPos = new Vector3(2, -15, -1);
            _ThirdPos = new Vector3(3.5f, -16, -1);
        }
        else if (today == 3)
        {
            _FirstPos = new Vector3(24, 7, -1);
            _SecondPos = new Vector3(50, 7, -1);
            _ThirdPos = new Vector3(5.5f, 15.5f, -1);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "NPC")
        {
            if(position == 3)
            {
                position = 0;
            }
            if (position == 2)
            {
                this.gameObject.transform.position = new Vector3(_ThirdPos.x, _ThirdPos.y, _ThirdPos.z);
                position = 3;
            }
            if (position == 1)
            {
                this.gameObject.transform.position = new Vector3(_SecondPos.x, _SecondPos.y, _SecondPos.z);
                position = 2;
            }
            if (position == 0)
            {
                this.gameObject.transform.position = new Vector3(_FirstPos.x, _FirstPos.y, _FirstPos.z);
                position = 1;
            }
        }
    }

}
