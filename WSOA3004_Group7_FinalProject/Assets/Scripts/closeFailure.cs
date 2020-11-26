using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closeFailure : MonoBehaviour
{
    public void CloseFailure(Transform trans)
    {
        trans.gameObject.SetActive(false);
        GameManagerScript.instance.Failure.SetActive(false);
    }
}
