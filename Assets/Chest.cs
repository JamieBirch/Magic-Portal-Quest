using UnityEngine;
using UnityEngine.EventSystems;
using Random = System.Random;

public class Chest : MonoBehaviour, InteractableItem
{
    // public float unlockDuration = 3;
    // public float countdown;

    /*private void Start()
    {
        countdown = unlockDuration;
    }*/

    private void OpenChest()
    {
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

        GameStats.chestsFound++;
    }

    private static void GetRelic()
    {
        Debug.Log("Got Relic");
        GameStats.relics++;
    }

    private void GetKey()
    {
        Debug.Log("Got Key");
        GameStats.keyFound = true;
    }

    private void Trap()
    {
        Debug.Log("Triggered trap");
        //TODO
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
