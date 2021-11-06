using UnityEngine;

public class Tile : MonoBehaviour
{
    public Vector3 position;
    public MapObjects TileObject;
}

public enum MapObjects
{
    StorageBox,
    PlantBox,
    SeedBox,
    ToolHarvest,
    ToolWateringCan
}
