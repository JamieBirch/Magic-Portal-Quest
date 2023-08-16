using UnityEngine;
using Random = System.Random;

public class Chest : MonoBehaviour
{
    // public bool isATrap = false;

    // Update is called once per frame
    public void OpenChest()
    {
        if (GameStats.chestsFound >= 2)
        {
            //chance to find a key
        }
        else
        {
            if (TossCoin())
            {
                //relic
            }
            else
            {
                //trap!
            }
        }

        GameStats.chestsFound++;
    }
    
    public static bool TossCoin()
    {
        Random random = new Random();
        float nextDouble = (float)random.NextDouble() * 100;
        return nextDouble >= 50;
    }
}
