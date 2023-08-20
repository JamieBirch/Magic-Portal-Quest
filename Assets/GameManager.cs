using UnityEngine;
using Random = System.Random;
using System.Collections.Generic;
using System.Linq;
using StarterAssets;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    private EndGame _endGameManager;
    public PlayerMessageService _messageService;
    
    public GameObject player;
    public Player playerComponent;
    public GameObject[] tiles;
    public GameObject chest;
    // public GameObject signalPoint;
    public Vector3[] tilePositions = {new Vector3(-6, 0, -6), new Vector3(-6, 0, 6), new Vector3(6, 0, -6), new Vector3(6, 0, 6)};
    public Vector3[] cornerPositions = {new Vector3(-11.5f, -1.5f, -11.5f), new Vector3(-11.5f, -1.5f, 11.5f), new Vector3(11.5f, -1.5f, -11.5f), new Vector3(11.5f, -1.5f, 11.5f)};
    private int exitPositionIndex;
    public string potentianPOITag = "potential_poi";
    private int chestsPerLocation = 7;
    
    public float gameDuration;
    public float countdown;
    public Image timerBar;
    
    public static bool gameStart = true;

    // public bool _gameOver = false;
    
    // public GameObject gameOverUI;
    
    // Start is called before the first frame update
    void Start()
    {
        GenerateMaze();
        // PlaceExit();
        // PlaceKey();
        PlaceChests();

        playerComponent = player.GetComponent<Player>();
        _endGameManager = EndGame.instance;
        
    }

    private void StartGame()
    {
        Debug.Log("Game Start");
        //TODO narration text
        
        // cameraShake.Shake(10000f, 2f);
        // player.GetComponent<FirstPersonController>().enabled = true;
        // Debug.Log("Controls enabled");

        gameStart = false;
        
        countdown = gameDuration;
    }

    private void Update()
    {
        if (gameStart)
        {
            StartGame();
        }
        
        if (GameStats.gameOver)
        {
            return;
        }
        if (playerComponent.health <= 0)
        {
            _messageService.ShowMessage("You're dead");
            Debug.Log("You're dead");
            GameOver();
        }

        if (countdown <= 0)
        {
            _messageService.ShowMessage("Time is out");
            Debug.Log("Time is out");
            GameOver();
        }

        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        timerBar.fillAmount = countdown / gameDuration;
    }

    private void GameOver()
    {
        GameStats.gameOver = true;
        _endGameManager.FinishGame(playerComponent, false);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void PlaceChests()
    {
        Vector3 chestOffset = new Vector3(0, 1, 0);
        // IEnumerable<Vector3> pois = GameObject.FindGameObjectsWithTag(potentianPOITag).Select(poi -> poi.transform.position);
        GameObject[] gameObjectsWithTag = GameObject.FindGameObjectsWithTag(potentianPOITag);
        List<Vector3> pois = new List<Vector3>();
        foreach (var go in gameObjectsWithTag)
        {
            pois.Add(go.transform.position);
        }
        IEnumerable<Vector3> positions = pois.Concat(cornerPositions);
        Vector3[] pickedPOIsLocations = positions.OrderBy(x => new Random().Next()).Take(chestsPerLocation/* + signalPointsPerLocation*/).ToArray();
        for (int i = 0; i < pickedPOIsLocations.Length; i++)
        {
            if (i < chestsPerLocation)
            {
                Instantiate(chest, pickedPOIsLocations[i]/*.transform.position*/ + chestOffset, Quaternion.identity);
            }
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
