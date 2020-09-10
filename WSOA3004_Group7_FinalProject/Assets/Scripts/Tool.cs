﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "Tool", menuName = "Tools")]
public class Tool : ScriptableObject
{
    public string toolType;
    public Animation toolAnim;
    public Sprite toolSprite;
    public Tile groundAfterToolTile;
}
