using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemiRubyCollide : MonoBehaviour
{
    public SpriteRenderer DemiRend;
    public Transform RubyFoot;
    public Transform DemiFoot;
    public int higherLayer = 10;
    public int lowerLayer = 8;

    // Update is called once per frame
    void Update()
    {
        if(DemiFoot.transform.position.y <= RubyFoot.transform.position.y)
        {
            DemiRend.sortingOrder = higherLayer;
        }
        else
        {
            DemiRend.sortingOrder = lowerLayer;
        }
    }
}
