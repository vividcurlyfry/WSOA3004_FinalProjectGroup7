using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "Crop",menuName ="Crops")]
public class Crop : ScriptableObject
{
    public string CropName;
    public string CropType;
    public Sprite SeedSprite;
    public Sprite FullGrownSprite;
    public Sprite[] GrowingSprites;
    public int DaysGrown;
    public Vector3 PlantedLocation;
    public Tile RequiredGround;
}
