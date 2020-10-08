using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeliveryScript : MonoBehaviour
{
    public GameObject[] DisplayOrder = new GameObject[6];
    public Text orderText;

    // Start is called before the first frame update
    void Start()
    {
        orderText.text = GameManagerScript.instance.order1.OrderText;
        DisplayOrder[0].GetComponentInChildren<Text>().text = "0/" + GameManagerScript.instance.order1.LettuceNeeded.ToString();
        DisplayOrder[1].GetComponentInChildren<Text>().text = "0/" + GameManagerScript.instance.order1.PotatoNeeded.ToString();
        DisplayOrder[2].GetComponentInChildren<Text>().text = "0/" + GameManagerScript.instance.order1.TurnipNeeded.ToString();
        DisplayOrder[3].GetComponentInChildren<Text>().text = "0/" + GameManagerScript.instance.order1.WatermelonNeeded.ToString();
        DisplayOrder[4].GetComponentInChildren<Text>().text = "0/" + GameManagerScript.instance.order1.CarrotNeeded.ToString();
        DisplayOrder[5].GetComponentInChildren<Text>().text = "0/" + GameManagerScript.instance.order1.PeachNeeded.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AcceptOrder()
    {
        GameManagerScript.instance.jute.gameObject.SetActive(true);
    }

    public void Clicked()
    {
        if(GameManagerScript.instance.SelectedObj.transform.Find("Item").GetComponent<SpriteRenderer>().sprite != null)
        {
            if(GameManagerScript.instance.SelectedObj.transform.Find("Item").GetComponent<SpriteRenderer>().sprite == GameManagerScript.instance.LettuceSeed.FullyGrownSprite)
            {
                if(GameManagerScript.instance.order1.LettuceNeeded != 0 && GameManagerScript.instance.order1.LettuceAmount != GameManagerScript.instance.order1.LettuceNeeded)
                {
                    GameManagerScript.instance.order1.LettuceAmount++;

                    int pos = GameManagerScript.instance.FindPos("Lettuce");
                    if (pos != -1)
                    {
                        GameManagerScript.instance.Inventory.inven[pos].ItemNumber--;
                    }
                    GameManagerScript.instance.DisplayInvenFunc();
                    DisplayOrder[0].GetComponentInChildren<Text>().text = GameManagerScript.instance.order1.LettuceAmount.ToString() + "/" + GameManagerScript.instance.order1.LettuceNeeded.ToString();
                }
            }

            if (GameManagerScript.instance.SelectedObj.transform.Find("Item").GetComponent<SpriteRenderer>().sprite == GameManagerScript.instance.TurnipSeed.FullyGrownSprite)
            {
                if (GameManagerScript.instance.order1.TurnipNeeded != 0 && GameManagerScript.instance.order1.TurnipAmount != GameManagerScript.instance.order1.TurnipNeeded)
                {
                    GameManagerScript.instance.order1.TurnipAmount++;

                    int pos = GameManagerScript.instance.FindPos("Turnip");
                    if (pos != -1)
                    {
                        GameManagerScript.instance.Inventory.inven[pos].ItemNumber--;
                    }
                    GameManagerScript.instance.DisplayInvenFunc();
                    DisplayOrder[2].GetComponentInChildren<Text>().text = GameManagerScript.instance.order1.TurnipAmount.ToString() + "/" + GameManagerScript.instance.order1.TurnipNeeded.ToString();
                }
            }

            if (GameManagerScript.instance.SelectedObj.transform.Find("Item").GetComponent<SpriteRenderer>().sprite == GameManagerScript.instance.PotatoSeed.FullyGrownSprite)
            {
                if (GameManagerScript.instance.order1.PotatoNeeded != 0 && GameManagerScript.instance.order1.PotatoAmount != GameManagerScript.instance.order1.PotatoNeeded)
                {
                    GameManagerScript.instance.order1.PotatoAmount++;

                    int pos = GameManagerScript.instance.FindPos("Potato");
                    if (pos != -1)
                    {
                        GameManagerScript.instance.Inventory.inven[pos].ItemNumber--;
                    }
                    GameManagerScript.instance.DisplayInvenFunc();
                    DisplayOrder[1].GetComponentInChildren<Text>().text = GameManagerScript.instance.order1.PotatoAmount.ToString() + "/" + GameManagerScript.instance.order1.PotatoNeeded.ToString();
                }
            }

            if (GameManagerScript.instance.SelectedObj.transform.Find("Item").GetComponent<SpriteRenderer>().sprite == GameManagerScript.instance.WatermelonSeed.FullyGrownSprite)
            {
                if (GameManagerScript.instance.order1.WatermelonNeeded != 0 && GameManagerScript.instance.order1.WatermelonAmount != GameManagerScript.instance.order1.WatermelonNeeded)
                {
                    GameManagerScript.instance.order1.WatermelonAmount++;

                    int pos = GameManagerScript.instance.FindPos("Watermelon");
                    if (pos != -1)
                    {
                        GameManagerScript.instance.Inventory.inven[pos].ItemNumber--;
                    }
                    GameManagerScript.instance.DisplayInvenFunc();
                    DisplayOrder[3].GetComponentInChildren<Text>().text = GameManagerScript.instance.order1.WatermelonAmount.ToString() + "/" + GameManagerScript.instance.order1.WatermelonNeeded.ToString();
                }
            }

            if (GameManagerScript.instance.SelectedObj.transform.Find("Item").GetComponent<SpriteRenderer>().sprite == GameManagerScript.instance.CarrotSeed.FullyGrownSprite)
            {
                if (GameManagerScript.instance.order1.CarrotNeeded != 0 && GameManagerScript.instance.order1.CarrotAmount != GameManagerScript.instance.order1.CarrotNeeded)
                {
                    GameManagerScript.instance.order1.CarrotAmount++;

                    int pos = GameManagerScript.instance.FindPos("Carrot");
                    if (pos != -1)
                    {
                        GameManagerScript.instance.Inventory.inven[pos].ItemNumber--;
                    }
                    GameManagerScript.instance.DisplayInvenFunc();
                    DisplayOrder[4].GetComponentInChildren<Text>().text = GameManagerScript.instance.order1.CarrotAmount.ToString() + "/" + GameManagerScript.instance.order1.CarrotNeeded.ToString();
                }
            }

            if((GameManagerScript.instance.order1.CarrotAmount == GameManagerScript.instance.order1.CarrotNeeded) && (GameManagerScript.instance.order1.TurnipAmount == GameManagerScript.instance.order1.TurnipNeeded) && (GameManagerScript.instance.order1.WatermelonAmount == GameManagerScript.instance.order1.WatermelonNeeded) && (GameManagerScript.instance.order1.LettuceAmount == GameManagerScript.instance.order1.LettuceNeeded) && (GameManagerScript.instance.order1.PotatoAmount == GameManagerScript.instance.order1.PotatoNeeded))
            {
                GameManagerScript.instance.jute.SetActive(false);
                GameManagerScript.instance.juteClosed.SetActive(true);
            }
        }
    }
}
