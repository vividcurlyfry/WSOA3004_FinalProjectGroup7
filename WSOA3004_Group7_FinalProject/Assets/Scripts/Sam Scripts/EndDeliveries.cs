﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndDeliveries : MonoBehaviour
{
    public GameObject truck;
    public GameObject deliveryPanel;
    public Order[] acceptedOrders;
    public Text money;
    public Text order;
    public string deliveredString;
    public Text rewardText;
    
    //set up delivered order and money increase
    private void Start()
    {
        int reward = 0;
        deliveredString = "";
        for(int a = 0; a < acceptedOrders.Length; a++)
        {
            if(acceptedOrders[a].Completed == true)
            {
                deliveredString += "Delivered to " + acceptedOrders[a].nameOrder + System.Environment.NewLine;
                reward += acceptedOrders[a].Reward;
                acceptedOrders[a].Delivered = true;
            }
        }

        money.text = (acceptedOrders[0].TotalFunds - reward).ToString();
        order.text = deliveredString;
        rewardText.text = reward.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(truck.transform.position.x > 2)
        {
            deliveryPanel.SetActive(true);
        }

        if(truck.transform.position.x > 8)
        {
            money.text = acceptedOrders[0].TotalFunds.ToString();
        }
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }
}
