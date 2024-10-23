using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;
using System.IO;

public class MapGenerator : MonoBehaviour
{
    public Tilemap floorTilemap;
    public Tilemap wallTilemap;
    public Tilemap emptyTilemap;
    public TileBase floorTile;
    public TileBase topFloorTile;
    public TileBase wallBottomTile;
    public TileBase wallMiddleTile;
    public TileBase wallTopTile;
    public TileBase wallRoofTile;
    public TileBase emptyTile;
    public GameObject matchstick;
    public GameObject objectiveItem;
    public GameObject exitItem;
    private string map;

    private List<GameObject> instantiatedObjects = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        int randomNumber = Random.Range(1, 6);
        map = "Map" + randomNumber;
        Debug.Log(map);
        ClearOldMap();
        GenerateMap(map);
        SpawnItems(map);
    }

    void GenerateMap(string map)
    {
        // Read CSV file
        string path = Path.Combine(Application.dataPath, "Maps", map, "tile_map.csv");
        string[] lines = File.ReadAllLines(path);
        for (int y = 0; y < lines.Length; y++)
        {
            string[] tiles = lines[y].Split(',');
            for (int x = 0; x < tiles.Length; x++)
            {
                int tileType = int.Parse(tiles[x]);
                Vector3Int tilePosition = new Vector3Int(y, -x, 0);


                // Instantiate the correct tile based on the tileType

                if (tileType >= 1)
                {
                    int aboveTileType = int.Parse(lines[y].Split(',')[x - 1]);
                    if (aboveTileType == 0)
                    {
                        floorTilemap.SetTile(tilePosition, topFloorTile);
                    }
                    else
                    {
                        floorTilemap.SetTile(tilePosition, floorTile);
                    }
                }
                else if (tileType == 0)
                {
                    if (x > 5 && int.Parse(lines[y].Split(',')[x - 1]) >= 1)
                    {
                        floorTilemap.SetTile(tilePosition, floorTile);
                    }
                    else
                    {
                        if (x < tiles.Length - 6 && int.Parse(lines[y].Split(',')[x + 1]) >= 1)
                        {
                            wallTilemap.SetTile(tilePosition, wallBottomTile);
                        }
                        else
                        {
                            emptyTilemap.SetTile(tilePosition, emptyTile);
                        }
                    }
                }
            }
        }
    }
    private void SpawnItems(string map)
    {
        List<Vector2> roomCenters = ReadRoomCentersFromCSV(map);
        int center_index = 0;
        foreach (Vector2 center in roomCenters)
        {
            if (1 == center_index)
            {
                // Convert room center to world position
                Vector3 spawnPosition = new Vector3(center.y, -1 * center.x, 0);
                // Instantiate the matchstick prefab at the room center
                GameObject newExitItem = Instantiate(exitItem, spawnPosition, Quaternion.identity);
                newExitItem.SetActive(true);
                instantiatedObjects.Add(newExitItem);
            }
            if (2 <= center_index && center_index <= 4)
            {
                // Convert room center to world position
                Vector3 spawnPosition = new Vector3(center.y, -1 * center.x, 0);
                // Instantiate the matchstick prefab at the room center
                GameObject newObjectiveItem = Instantiate(objectiveItem, spawnPosition, Quaternion.identity);
                newObjectiveItem.SetActive(true);
                instantiatedObjects.Add(newObjectiveItem);
            }
            if (center_index >= 5)
            {
                float randomValue = Random.value;
                if (randomValue < 1.0f)
                {
                    // Convert room center to world position
                    Vector3 spawnPosition = new Vector3(center.y, -1 * center.x, 0);
                    // Instantiate the matchstick prefab at the room center
                    GameObject newMatchstick = Instantiate(matchstick, spawnPosition, Quaternion.identity);
                    newMatchstick.SetActive(true);
                    instantiatedObjects.Add(newMatchstick);
                }
            }
            center_index++;
        }
    }

    private List<Vector2> ReadRoomCentersFromCSV(string map)
    {
        string path = Path.Combine(Application.dataPath, "Maps", map, "room_centers.csv");
        List<Vector2> roomCenters = new List<Vector2>();

        // Read the CSV file
        using (StreamReader reader = new StreamReader(path))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                // Split the line into parts
                string[] values = line.Split(',');
                if (values.Length == 2)
                {
                    // Parse the x and y coordinates
                    float x = float.Parse(values[0]);
                    float y = float.Parse(values[1]);
                    roomCenters.Add(new Vector2(x, y));
                }
            }
        }

        return roomCenters;
    }

    void ClearOldMap()
    {
        // Clear all tiles to prevent memory leaks
        floorTilemap.ClearAllTiles();
        wallTilemap.ClearAllTiles();
        emptyTilemap.ClearAllTiles();

        // Destroy any previously instantiated objects
        foreach (GameObject obj in instantiatedObjects)
        {
            if (obj != null)
            {
                Destroy(obj);
            }
        }

        // Clear the list of instantiated objects
        instantiatedObjects.Clear();

        // Force garbage collection (optional, but can be used for debugging)
        System.GC.Collect();
    }
}
