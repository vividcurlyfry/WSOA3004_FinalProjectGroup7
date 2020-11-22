using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GroceriesTrack : MonoBehaviour
{
    public int GroceriesDays; //Day to buy groceries, Day 1 i.e. first day to buy groceries in this period
    public bool GroceriesNotBought, GroceriesBought; //connect to amy
    public int daysLeftInt;
    public Text daysLeft, GroceriesBoughtText, GroceriesLate;
    public GameObject HungryRuby;

    // Start is called before the first frame update
    void Start()
    {
        // GroceriesDays connect to AMy //put a bought check, if bought loop back to one it not bought keep counting
        GroceriesLate.enabled = false;
        GroceriesBoughtText.enabled = false;
        daysLeft.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(GroceriesBought)
        {
            GroceriesNotBought = false;
        }
        else
        {
            GroceriesNotBought = true;
        }

        if((GroceriesNotBought)&&(GroceriesDays < 4))
        {
            daysLeftInt = 4 - GroceriesDays;
            daysLeft.text = daysLeftInt.ToString() + " days left to buy groceries";
        }

        if ((GroceriesNotBought) && (GroceriesDays > 3))
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
        switch (GroceriesDays)
        {
            case 1:
                //display groceries bought for today and next 2 days
                GroceriesLate.enabled = false;
                GroceriesBoughtText.enabled = true;
                daysLeft.enabled = false;
                GroceriesBought = true;
                break;
            case 2:
                //display groceries bought for today and 1 day
                GroceriesLate.enabled = false;
                GroceriesBoughtText.enabled = true;
                daysLeft.enabled = false;
                GroceriesBought = true;
                break;
            case 3:
                //display groceries bought for today
                GroceriesLate.enabled = false;
                GroceriesBoughtText.enabled = true;
                daysLeft.enabled = false;
                GroceriesBought = true;
                break;
            default:
                //reset to 3 days to buy groceries the next day
                GroceriesLate.enabled = false;
                GroceriesBoughtText.enabled = true;
                daysLeft.enabled = false;
                GroceriesBought = true;
                break;
        }
    }
}
