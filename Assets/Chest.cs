using UnityEngine;
using Random = System.Random;

public class Chest : MonoBehaviour
{
    public void OpenChest()
    {
        if (GameStats.chestsFound >= 2 && !GameStats.keyFound)
        {
            //chance to find a key
        } else if (GameStats.chestsFound == 6)
        {
            //find key
        } else
        {
            if (TossCoin())
            {
                //relic
                GameStats.relics++;
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
