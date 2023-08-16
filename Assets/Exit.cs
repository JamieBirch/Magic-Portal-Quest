using UnityEngine;

public class Exit : MonoBehaviour, InteractableItem
{
    public void interact(Player player)
    {
        Debug.Log("Interact with exit");
        if (GameStats.keyFound)
        {
            Debug.Log("You won!");
        }
        else
        {
            Debug.Log("You need to find the key!");
        }
    }
}
