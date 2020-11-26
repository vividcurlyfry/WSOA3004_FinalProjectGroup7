using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCPath : MonoBehaviour
{
    public int position = 0;
    public bool isRaining = false;

    private Vector3 _FirstPos, _SecondPos, _ThirdPos;

    ////////////// NOTE ////////////////
    //Day 1: Hanging on the farm
    //Day 2: Beekeeping
    //Day 3: Going to town
    ////////////////////////////////////
   

    private void Start()
    {
        isRaining = GameObject.FindGameObjectWithTag("GameManager").GetComponent<LivelinessEffects>().Raining;
        Debug.Log("Ruby today " + GameManagerScript.instance.RubyLoop);
        if (isRaining)
        {
            _FirstPos = new Vector3(8f, 15f, -1);
            _SecondPos = new Vector3(4f, 15f, -1);
            _ThirdPos = new Vector3(17.69f, 16f, -1);
        }
        else if (GameManagerScript.instance.RubyLoop == 0)
        {
            _FirstPos = new Vector3(21f, 15, -1);
            _SecondPos = new Vector3(0, 15, -1);
            _ThirdPos = new Vector3(4f, 15f, -1);
        }
        else if (GameManagerScript.instance.RubyLoop == 1)
        {
            _FirstPos = new Vector3(4f, 2, -1);
            _SecondPos = new Vector3(2, -15, -1);
            _ThirdPos = new Vector3(3.5f, -16, -1);
        }
        else if (GameManagerScript.instance.RubyLoop == 2)
        {
            _FirstPos = new Vector3(24, 7, -1);
            _SecondPos = new Vector3(50, 7, -1);
            _ThirdPos = new Vector3(8f, 15f, -1);
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
