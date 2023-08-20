using System;
using UnityEngine;
using Random = System.Random;

public class Chest : MonoBehaviour, InteractableItem
{
    private PlayerMessageService _messageService;
    
    public GameObject defaultChest;
    public GameObject openChest;
    private bool isOpen = false;

    private void OpenChest(Player player)
    {
        if (_messageService == null)
        {
            _messageService = PlayerMessageService.instance;
        }
        Debug.Log("Opening chest " + GameStats.chestsFound);
        if (isOpen)
        {
            _messageService.ShowMessage("Chest already open");
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
        _messageService.ShowMessage("Relic found");
        Debug.Log("Got Relic");
        ChestsManager.instance.ShowRelic(GameStats.chestsFound);
        GameStats.relics++;
    }

    private void GetKey()
    {
        _messageService.ShowMessage("Support Found!");
        Debug.Log("Support Found");
        GameStats.keyFound = true;
        ChestsManager.instance.ShowKey(GameStats.chestsFound);
    }

    private void Trap(Player player)
    {
        _messageService.ShowMessage("Trap triggered");
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
