using UnityEngine;

public class Tile : MonoBehaviour
{
    public Vector3 position;
    public MapObjects TileObject;

    public GameObject highlightObject;

    public Light highlightLight;
    public int intensityCounter;

    public void Start()
    {
        highlightLight = Instantiate(highlightObject, this.transform).GetComponent<Light>();
        highlightLight.intensity = 2f;
    }

    public void Highlight(bool isHighlighted)
    {
        //if (highlightLight == null) highlightLight = GetComponent<Light>();

        if (isHighlighted)
        {
            highlightLight.intensity = 2f;
        }
        else
        {
            highlightLight.intensity = 0f;
        }
    }
}

public enum MapObjects
{
    StorageBox,
    PlantBox,
    SeedBox,
    ToolHarvest,
    ToolWateringCan
}
