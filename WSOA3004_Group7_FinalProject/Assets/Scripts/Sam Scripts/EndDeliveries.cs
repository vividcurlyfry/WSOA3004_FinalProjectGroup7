using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndDeliveries : MonoBehaviour
{
    public GameObject truck;
    public GameObject deliveryPanel;
    public Order thisOrder;
    public Text money;
    public Text order;
    
    //set up delivered order and money increase
    private void Start()
    {
        //order.text = //something from amy
    }

    // Update is called once per frame
    void Update()
    {
        if(truck.transform.position.x > 2)
        {
            deliveryPanel.SetActive(true);
        }

        if(truck.transform.position.x > 4)
        {
            // money.text = (thisOrder.Reward + //currentTotal).ToString();
        }
    }
}
