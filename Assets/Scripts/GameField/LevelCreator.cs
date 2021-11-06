using System.Collections.Generic;
using UnityEngine;

public class LevelCreator : MonoBehaviour
{
    public Tile[] TileObjects;
    public List<GameObject> gameObjects;
    public string Name;

    public GameObject StorageBox;
    public GameObject SeedBox;
    public GameObject PlantBox;
    public GameObject ToolHarvest;
    public GameObject ToolWateringCan;

    void Start()
    {
        StartLevel();   
    }

    void StartLevel()
    {
        CreateTiles();
    }

    void CreateTiles()
    {
        foreach (var tileObject in TileObjects)
        {
            GameObject gameObject;
          
            switch (tileObject.TileObject)
            {
                case MapObjects.PlantBox:
                    gameObject = PlantBox;
                    break;
                case MapObjects.SeedBox:
                    gameObject = SeedBox;
                    break;
                case MapObjects.StorageBox:
                    gameObject = StorageBox;
                    break;
                case MapObjects.ToolHarvest:
                    gameObject = ToolHarvest;
                    break;
                case MapObjects.ToolWateringCan:
                    gameObject = ToolWateringCan;
                    break;
                default:
                    throw new System.Exception("Enum value not found");
            }

            var instance = GameObject.Instantiate(gameObject, tileObject.position, Quaternion.identity, this.transform);
            
            gameObjects.Add(instance);
        }
    }

    void UnloadTiles()
    {
        foreach (var gameObject in gameObjects)
        {
            GameObject.Destroy(gameObject);
        }
    }
}
