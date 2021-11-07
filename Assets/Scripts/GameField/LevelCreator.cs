using System.Collections.Generic;
using UnityEngine;

public class LevelCreator : MonoBehaviour
{
    public List<GameObject> GameObjects;
    public List<Tile> ObjectInstances;
    public List<Vector3> Positions;
    
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
        for (var i = 0; i < GameObjects.Count; i++)
        {
            var tile = GameObjects[i].GetComponent<Tile>();
            tile.position = Positions[i];
            ObjectInstances.Add(GameObject.Instantiate(tile, tile.position, Quaternion.identity, this.transform));
        }
    }

    void UnloadTiles()
    {
        foreach (var gameObject in GameObjects)
        {
            GameObject.Destroy(gameObject);
        }
    }
}
