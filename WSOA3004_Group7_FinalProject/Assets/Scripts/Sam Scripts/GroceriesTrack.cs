using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GroceriesTrack : MonoBehaviour
{
    public bool GroceriesNotBought; //connect to amy to save
    public int daysLeftInt;
    public Text daysLeft, GroceriesBoughtText, GroceriesLate;
    public GameObject HungryRuby;

    // Start is called before the first frame update
    void Start()
    {
        //GroceriesDays connect to AMy //put a bought check, if bought loop back to one it not bought keep counting
        //GroceriesBought 
        GroceriesLate.enabled = false;
        GroceriesBoughtText.enabled = false;
        daysLeft.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManagerScript.instance.GroceriesBought)
        {
            GroceriesNotBought = false;
        }
        else
        {
            GroceriesNotBought = true;
        }

        if((GroceriesNotBought)&&(GameManagerScript.instance.GroceriesDays < 4))
        {
            daysLeftInt = 4 - GameManagerScript.instance.GroceriesDays;
            daysLeft.text = daysLeftInt.ToString() + " days left to buy groceries";
            HungryRuby.SetActive(false);
        }

        if ((GroceriesNotBought) && (GameManagerScript.instance.GroceriesDays > 3))
        {
            //make Ruby Hungry
            HungryRuby.SetActive(true);

            //display Warning: Must buy groceries, low on food.
            GroceriesLate.enabled = true;
            GroceriesBoughtText.enabled = false;
            daysLeft.enabled = false;
        }
    }

    public void CheckGroceries()
    {
        switch (GameManagerScript.instance.GroceriesDays)
        {
            case 1:
                //display groceries bought for today and next 2 days
                GroceriesLate.enabled = false;
                GroceriesBoughtText.enabled = true;
                daysLeft.enabled = false;
                GameManagerScript.instance.GroceriesBought = true;
                break;
            case 2:
                //display groceries bought for today and 1 day
                GroceriesLate.enabled = false;
                GroceriesBoughtText.enabled = true;
                daysLeft.enabled = false;
                GameManagerScript.instance.GroceriesBought = true;
                break;
            case 3:
                //display groceries bought for today
                GroceriesLate.enabled = false;
                GroceriesBoughtText.enabled = true;
                daysLeft.enabled = false;
                GameManagerScript.instance.GroceriesBought = true;
                break;
            default:
                //reset to 3 days to buy groceries the next day
                GroceriesLate.enabled = false;
                GroceriesBoughtText.enabled = true;
                daysLeft.enabled = false;
                GameManagerScript.instance.GroceriesBought = true;
                HungryRuby.SetActive(false);
                break;
        }
    }
}
