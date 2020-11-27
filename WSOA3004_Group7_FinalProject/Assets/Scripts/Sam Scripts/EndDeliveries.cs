using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndDeliveries : MonoBehaviour
{
    public GameObject truck;
    public GameObject deliveryPanel;
    public Text money;
    public Text order;
    public string deliveredString;
    public Text rewardText;
    public AudioSource AS;
    public int reward;
    public Text honeyText;
    public int honey;

    //set up delivered order and money increase
    private void Start()
    {
        if (PlayerPrefs.GetString("NeedHoney") == "no")
        {
            int honey = PlayerPrefs.GetInt("Honey");
            reward = honey;
            honeyText.text = "+ " + honey.ToString();
            deliveredString = "";
            for (int a = 0; a < GameManagerScript.instance.acceptedOrders.Length; a++)
            {
                if (GameManagerScript.instance.acceptedOrders[a].Completed == true)
                {
                    deliveredString += "Delivered to " + GameManagerScript.instance.acceptedOrders[a].nameOrder + " + " + GameManagerScript.instance.acceptedOrders[a].Reward + System.Environment.NewLine;
                    reward += GameManagerScript.instance.acceptedOrders[a].Reward;
                    GameManagerScript.instance.acceptedOrders[a].Delivered = true;
                }
            }

            money.text = (GameManagerScript.instance.acceptedOrders[0].TotalFunds).ToString();
            order.text = deliveredString;
            rewardText.text = reward.ToString();
        }
        else
        {
            int honey = 75;
            reward = honey;
            honeyText.text = "+ " + honey.ToString();

            money.text = (GameManagerScript.instance.acceptedOrders[0].TotalFunds).ToString();
            order.text = "No orders delivered today. But Ruby sold some honey!";
            rewardText.text = reward.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(truck.transform.position.x > 2)
        {
            deliveryPanel.SetActive(true);
        }

        if(truck.transform.position.x > 12.7f)
        {
            money.text = (GameManagerScript.instance.acceptedOrders[0].TotalFunds + reward).ToString();
            AS.volume = 1;
        }

        if (truck.transform.position.x > 16.5f)
        {
            AS.volume = 0;
        }
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }
}
