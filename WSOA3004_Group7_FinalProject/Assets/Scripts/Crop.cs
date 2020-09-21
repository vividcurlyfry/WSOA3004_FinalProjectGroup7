using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "Crop",menuName ="Crops")]
public class Crop : ScriptableObject
{
    public string CropName;
    public string CropType;
    public int CropPrice;
    public int DaysToGrow;
    public Sprite SeedSprite;
    public Sprite FullGrownSprite;
    public Tile[] GrowingTiles;
    public int DaysGrown;
    public Vector3 PlantedLocation;
    public Tile RequiredGround;
}
