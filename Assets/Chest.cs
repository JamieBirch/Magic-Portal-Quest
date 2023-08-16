using UnityEngine;
using Random = System.Random;

public class Chest : MonoBehaviour, InteractableItem
{
    // public float unlockDuration = 3;
    // public float countdown;

    /*private void Start()
    {
        countdown = unlockDuration;
    }*/

    private bool isOpen = false;

    public GameObject chestsUIPanel;

    private void OpenChest()
    {
        if (isOpen)
        {
            return;
        }
        if (GameStats.chestsFound >= 2 && !GameStats.keyFound)
        {
            if (OneOfTree())
            {
                GetKey();
            }
        } else if (GameStats.chestsFound == 6)
        {
            GetKey();
        } else
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

        isOpen = true;
        GameStats.chestsFound++;
    }

    private void GetRelic()
    {
        Debug.Log("Got Relic");
        GameObject chestPanel = chestsUIPanel.GetComponent<ChestsUiList>().chestsPanelsArray[GameStats.chestsFound];
        chestPanel.GetComponent<ChestUI>().ShowRelic();
        GameStats.relics++;
    }

    private void GetKey()
    {
        Debug.Log("Got Key");
        GameStats.keyFound = true;
        GameObject chestPanel = chestsUIPanel.GetComponent<ChestsUiList>().chestsPanelsArray[GameStats.chestsFound];
        chestPanel.GetComponent<ChestUI>().ShowKey();
    }

    private void Trap()
    {
        Debug.Log("Triggered trap");
        GameObject chestPanel = chestsUIPanel.GetComponent<ChestsUiList>().chestsPanelsArray[GameStats.chestsFound];
        chestPanel.GetComponent<ChestUI>().ShowTrap();
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
