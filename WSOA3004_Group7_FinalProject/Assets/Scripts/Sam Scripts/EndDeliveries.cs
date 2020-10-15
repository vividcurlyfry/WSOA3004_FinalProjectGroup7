using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        money.text = (thisOrder.TotalFunds - thisOrder.Reward).ToString();
        thisOrder.Delivered = true;
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
             money.text = thisOrder.TotalFunds.ToString();
        }
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene("GameScene");
       //SceneManager.LoadScene("EndOfDay");
    }
}
