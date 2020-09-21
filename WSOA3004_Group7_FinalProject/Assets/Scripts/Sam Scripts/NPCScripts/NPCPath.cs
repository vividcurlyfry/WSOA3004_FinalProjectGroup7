using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCPath : MonoBehaviour
{
    public int position = 0;
    [SerializeField]
    public Vector3 _FirstPos, _SecondPos, _ThirdPos;

    private void Start()
    {
        //if Day 1 set positions to x, y, z - need day cycle class
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
