using UnityEngine;
using Random = System.Random;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


public class GameManager : MonoBehaviour
{
    public GameObject player;
    public Player playerComponent;
    public GameObject[] tiles;
    public GameObject exit;
    public GameObject key;
    public GameObject chest;
    // public GameObject signalPoint;
    public Vector3[] tilePositions = {new Vector3(-6, 0, -6), new Vector3(-6, 0, 6), new Vector3(6, 0, -6), new Vector3(6, 0, 6)};
    public Vector3[] cornerPositions = {new Vector3(-11.5f, 0, -11.5f), new Vector3(-11.5f, 0, 11.5f), new Vector3(11.5f, 0, -11.5f), new Vector3(11.5f, 0, 11.5f)};
    private int exitPositionIndex;
    public string potentianPOITag = "potential_poi";
    private int chestsPerLocation = 7;
    // private int signalPointsPerLocation = 4;
    
    // Start is called before the first frame update
    void Start()
    {
        GenerateMaze();
        PlaceExit();
        PlaceKey();
        PlaceChests();

        playerComponent = player.GetComponent<Player>();
    }

    private void Update()
    {
        if (playerComponent.health <= 0)
        {
            Debug.Log("GameOver");
        }
    }

    private void PlaceKey()
    {
        int keyPositionIndex = new Random().Next(0, cornerPositions.Length);
        //avoid placing in same corner
        while (keyPositionIndex == exitPositionIndex)
        {
            keyPositionIndex = new Random().Next(0, cornerPositions.Length);
        }
        Vector3 cornerPosition = cornerPositions[keyPositionIndex];
        Instantiate(key, cornerPosition, Quaternion.identity);
    }

    private void PlaceExit()
    {
        exitPositionIndex = new Random().Next(0, cornerPositions.Length);
        Vector3 cornerPosition = cornerPositions[exitPositionIndex];
        Instantiate(exit, cornerPosition, Quaternion.identity);
    }

    private void PlaceChests()
    {
        Vector3 chestOffset = new Vector3(0, 1.5f, 0);
        IEnumerable<Vector3> pois = GameObject.FindGameObjectsWithTag(potentianPOITag).Select(poi -> poi.transform.position);
        IEnumerable<Vector3> positions = pois.Concat(cornerPositions);
        // potentialPOIS.Select(a -> a.transform.position)
        Vector3[] pickedPOIsLocations = positions.OrderBy(x => new Random().Next()).Take(chestsPerLocation/* + signalPointsPerLocation*/).ToArray();
        for (int i = 0; i < pickedPOIsLocations.Length; i++)
        {
            /*if (i < chestsPerLocation/2)
            {
                Instantiate(chest, pickedPOIsLocations[i].transform.position + chestOffset, Quaternion.identity);
            } else */if (i < chestsPerLocation)
            {
                Instantiate(chest, pickedPOIsLocations[i]/*.transform.position*/ + chestOffset, Quaternion.identity);
                // chest.GetComponent<Chest>().isATrap = true;
            }
            /*else
            {
                Instantiate(signalPoint, pickedPOIsLocations[i].transform.position + chestOffset, Quaternion.identity);
                // Debug.Log("placed signal spot");
            }*/
        }
    }

    private void GenerateMaze()
    {
        foreach (var tilePosition in tilePositions)
        {
            int tileIndex = new Random().Next(0, tiles.Length);
            GameObject tile = tiles[tileIndex];

            int randomRotationMultiplier = new Random().Next(0, 4);
            Quaternion angleAxis = Quaternion.AngleAxis(90 * randomRotationMultiplier, Vector3.up);

            Instantiate(tile, tilePosition, angleAxis);
        }
    }
}
