using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MapGenerator : MonoBehaviour
{
    public GameObject floorTile;
    public GameObject topFloorTile;
    public GameObject wallBottomTile;
    public GameObject wallMiddleTile;
    public GameObject wallTopTile;
    public GameObject wallRoofTile;
    public GameObject emptyTile;
    public GameObject matchstick;
    public GameObject objectiveItem;
    public GameObject exitItem;

    // Start is called before the first frame update
    void Start()
    {
        GenerateMap();
        SpawnItems();

    }

    void GenerateMap()
    {
        // Read CSV file
        string path = Path.Combine(Application.dataPath, "Maps", "Map1", "tile_map.csv");
        string[] lines = File.ReadAllLines(path);
        for (int y = 0; y < lines.Length; y++)
        {
            string[] tiles = lines[y].Split(',');
            for (int x = 0; x < tiles.Length; x++)
            {
                int tileType = int.Parse(tiles[x]);
                GameObject tile = null;

                // Instantiate the correct tile based on the tileType

                if (tileType == 0)
                {
                    tile = Instantiate(emptyTile, new Vector3(y, -x, 0), Quaternion.identity);
                    tile.SetActive(true);
                }
                if (tileType >= 1)
                {
                    int aboveTileType = int.Parse(lines[y].Split(',')[x - 1]);
                    if (aboveTileType == 0) // Assuming '0' is a wall tile
                    {
                        tile = Instantiate(topFloorTile, new Vector3(y, -x, 0), Quaternion.identity);
                        tile.SetActive(true);
                        // tile = Instantiate(wallBottomTile, new Vector3(y, -x - 1, 0), Quaternion.identity);
                        // tile.SetActive(true);
                        // tile = Instantiate(wallMiddleTile, new Vector3(y, -x - 2, 0), Quaternion.identity);
                        // tile.SetActive(true);
                        // tile = Instantiate(wallTopTile, new Vector3(y, -x - 3, 0), Quaternion.identity);
                        // tile.SetActive(true);
                        // tile = Instantiate(wallRoofTile, new Vector3(y, -x - 4, 0), Quaternion.identity);
                        // tile.SetActive(true);
                    }
                    else
                    {
                        tile = Instantiate(floorTile, new Vector3(y, -x, 0), Quaternion.identity);
                        tile.SetActive(true);
                    }

                }

                // Optional: Set the parent to keep the hierarchy clean
                if (tile != null)
                {
                    tile.transform.parent = transform;
                }
            }
        }
    }
    private void SpawnItems()
    {
        List<Vector2> roomCenters = ReadRoomCentersFromCSV();
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
            }
            if (2 <= center_index && center_index <= 4)
            {
                // Convert room center to world position
                Vector3 spawnPosition = new Vector3(center.y, -1 * center.x, 0);
                // Instantiate the matchstick prefab at the room center
                GameObject newObjectiveItem = Instantiate(objectiveItem, spawnPosition, Quaternion.identity);
                newObjectiveItem.SetActive(true);
            }
            if (center_index >= 5)
            {
                // Convert room center to world position
                Vector3 spawnPosition = new Vector3(center.y, -1 * center.x, 0);
                // Instantiate the matchstick prefab at the room center
                GameObject newMatchstick = Instantiate(matchstick, spawnPosition, Quaternion.identity);
                newMatchstick.SetActive(true);
            }
            center_index++;
        }
    }

    private List<Vector2> ReadRoomCentersFromCSV()
    {
        string filePath = "Assets/Maps/Map1/room_centers.csv";
        List<Vector2> roomCenters = new List<Vector2>();

        // Read the CSV file
        using (StreamReader reader = new StreamReader(filePath))
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
}
