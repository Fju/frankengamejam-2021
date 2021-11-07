using UnityEngine;

public class Tile : MonoBehaviour
{
    public Vector3 position;
    public MapObjects TileObject;

    public virtual void Interaction(PlayerContoller gameObject)
    {
        throw new System.NotImplementedException();
    }
}

public enum MapObjects
{
    StorageBox,
    PlantBox,
    SeedBox,
    
    ToolWateringCan,
    ToolSickle,

    FruitCarrot
}
