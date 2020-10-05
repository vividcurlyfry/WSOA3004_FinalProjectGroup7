using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deliveries : MonoBehaviour
{
    public GameObject truck;
    public GameObject deliveryPanel;

    // Update is called once per frame
    void Update()
    {
        if(truck.transform.position.x > 0)
        {
            deliveryPanel.SetActive(true);
        }
    }
}
