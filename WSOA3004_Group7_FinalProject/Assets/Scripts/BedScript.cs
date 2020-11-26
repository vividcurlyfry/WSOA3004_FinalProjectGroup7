using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedScript : MonoBehaviour
{
    public GameObject showDoor;

    private void OnTriggerEnter2D(Collider2D collision)
    {
       // Debug.Log("collided");
        if (collision.gameObject.tag == "Player")
        {
          //  Debug.Log("true");
            GameManagerScript.instance.NearBed = true;
            showDoor.SetActive(true);
            GameManagerScript.instance.hovering = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManagerScript.instance.NearBed = false;
            showDoor.SetActive(false);
            GameManagerScript.instance.hovering = false;
        }
    }
}
