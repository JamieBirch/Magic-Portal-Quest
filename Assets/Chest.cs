using System;
using UnityEngine;
using Random = System.Random;

public class Chest : MonoBehaviour, InteractableItem
{
    private ChestsManager _chestsManager;
    private bool isOpen = false;

    // public GameObject chestsUIPanel;

    private void Awake()
    {
        _chestsManager = ChestsManager.instance;
    }

    private void OpenChest()
    {
        Debug.Log("Opening chest " + GameStats.chestsFound);
        if (isOpen)
        {
            Debug.Log("Chest already open");
            return;
        }
        if (GameStats.chestsFound >= 2 && !GameStats.keyFound)
        {
            Debug.Log("Chance to get a key");
            if (OneOfTree())
            {
                Debug.Log("Lucky!");
                GetKey();
            }
            else
            {
                Debug.Log("Unlucky!");
                GetRelicOrTrap();
            }
        } else if (GameStats.chestsFound == 6 && !GameStats.keyFound)
        {
            Debug.Log("last Chest, get key");
            GetKey();
        } else
        {
            GetRelicOrTrap();
        }

        isOpen = true;
        GameStats.chestsFound++;
    }

    private void GetRelicOrTrap()
    {
        if (TossCoin())
        {
            //relic
            GetRelic();
        }
        else
        {
            //trap!
            Trap();
        }
    }

    private void GetRelic()
    {
        Debug.Log("Got Relic");
        _chestsManager.ShowRelic(GameStats.chestsFound);
        /*GameObject chestPanel = chestsUIPanel.GetComponent<ChestsUiList>().chestsPanelsArray[GameStats.chestsFound];
        chestPanel.GetComponent<ChestUI>().ShowRelic();*/
        GameStats.relics++;
    }

    private void GetKey()
    {
        Debug.Log("Got Key");
        GameStats.keyFound = true;
        _chestsManager.ShowKey(GameStats.chestsFound);
        /*GameObject chestPanel = chestsUIPanel.GetComponent<ChestsUiList>().chestsPanelsArray[GameStats.chestsFound];
        chestPanel.GetComponent<ChestUI>().ShowKey();*/
    }

    private void Trap()
    {
        Debug.Log("Triggered trap");
        _chestsManager.ShowTrap(GameStats.chestsFound);
        /*GameObject chestPanel = chestsUIPanel.GetComponent<ChestsUiList>().chestsPanelsArray[GameStats.chestsFound];
        chestPanel.GetComponent<ChestUI>().ShowTrap();*/
        //TODO: playerHealth-=30;
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

    public void interact()
    {
        Debug.Log("Interact with chest");
        OpenChest();
    }
}
