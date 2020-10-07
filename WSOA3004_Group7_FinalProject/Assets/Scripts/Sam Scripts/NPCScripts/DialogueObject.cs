using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueObject
{
    [TextArea(3, 10)]
    public string[] conversations;
}
