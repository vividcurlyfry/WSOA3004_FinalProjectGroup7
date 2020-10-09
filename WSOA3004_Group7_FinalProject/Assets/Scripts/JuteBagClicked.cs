using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuteBagClicked : MonoBehaviour
{
    public GameObject gm;
    public GameObject jutecanvas;
    private void OnMouseDown()
    {
        gm.GetComponent<DeliveryScript>().Clicked();
    }

    private void OnMouseOver()
    {
        jutecanvas.SetActive(true);
    }

    private void OnMouseExit()
    {
        jutecanvas.SetActive(false);
    }
}
