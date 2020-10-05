using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "Crop",menuName ="Crops")]
[System.Serializable]
public class Crop : ScriptableObject
{
    public string CropName;
    public string CropType;
    public int CropPrice;
    public int DaysToGrow;
    public Sprite SeedSprite;
    public Tile[] GrowingTiles;
    public List<int> DaysGrown;
    public List<Vector3Int> PlantedLocations;
    public List<bool> Watered;
    public Tile RequiredGround;
}
