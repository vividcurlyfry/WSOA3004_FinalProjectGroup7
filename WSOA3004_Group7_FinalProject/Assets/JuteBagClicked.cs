using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuteBagClicked : MonoBehaviour
{
    public GameObject gm;
    private void OnMouseDown()
    {
        gm.GetComponent<DeliveryScript>().Clicked();
    }
}
