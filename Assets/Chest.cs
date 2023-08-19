using UnityEngine;
using Random = System.Random;

public class Chest : MonoBehaviour, InteractableItem
{
    // private ChestsManager _chestsManager;
    public GameObject defaultChest;
    public GameObject openChest;
    private bool isOpen = false;

    // public GameObject chestsUIPanel;

    private void Awake()
    {
        // _chestsManager = ChestsManager.instance;
    }

    private void OpenChest(Player player)
    {
        Debug.Log("Opening chest " + GameStats.chestsFound);
        if (isOpen)
        {
            PlayerMessageService.instance.ShowMessage("Chest already open");
            Debug.Log("Chest already open");
            return;
        }
        if (GameStats.chestsFound >= 2 && GameStats.chestsFound < 6 && !GameStats.keyFound)
        {
            Debug.Log("Chance to get a key");
            if (TossCoin())
            {
                Debug.Log("Lucky!");
                GetKey();
            }
            else
            {
                Debug.Log("Unlucky!");
                GetRelicOrTrap(player);
            }
        } else if (GameStats.chestsFound == 6 && !GameStats.keyFound)
        {
            Debug.Log("last Chest, get key");
            GetKey();
        } else 
        {
            GetRelicOrTrap(player);
        }

        isOpen = true;
        defaultChest.SetActive(false);
        openChest.SetActive(true);
        GameStats.chestsFound++;
    }

    private void GetRelicOrTrap(Player player)
    {
        if (GameStats.traps == 2 && !GameStats.keyFound)
        {
            GetRelic();
        }
        else
        {
            if (OneOfTree())
            {
                //trap!
                Trap(player);
            }
            else
            {
                //relic
                GetRelic();
            }
        }
    }

    private void GetRelic()
    {
        PlayerMessageService.instance.ShowMessage("Relic found");
        Debug.Log("Got Relic");
        ChestsManager.instance.ShowRelic(GameStats.chestsFound);
        GameStats.relics++;
    }

    private void GetKey()
    {
        PlayerMessageService.instance.ShowMessage("Key Found!");
        Debug.Log("Key Found");
        GameStats.keyFound = true;
        ChestsManager.instance.ShowKey(GameStats.chestsFound);
    }

    private void Trap(Player player)
    {
        PlayerMessageService.instance.ShowMessage("Trap triggered");
        Debug.Log("Triggered trap");
        ChestsManager.instance.ShowTrap(GameStats.chestsFound);
        player.health -= 35;
        player.LoseHeart();
        GameStats.traps++;
    }

    private static bool TossCoin()
    {
        Random random = new Random();
        float nextDouble = (float)random.NextDouble() * 100;
        return nextDouble >= 50;
    }

    private static bool OneOfTree()
    {
        Random random = new Random();
        float nextDouble = (float)random.NextDouble() * 100;
        return nextDouble <= 30;
    }

    public void interact(Player player)
    {
        Debug.Log("Interact with chest");
        OpenChest(player);
    }
}
