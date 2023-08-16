using UnityEngine;

public class Exit : MonoBehaviour, InteractableItem
{
    public void interact(Player player)
    {
        Debug.Log("Interact with exit");
        if (GameStats.keyFound)
        {
            PlayerMessageService.instance.ShowMessage("You won!");
            Debug.Log("You won!");
        }
        else
        {
            PlayerMessageService.instance.ShowMessage("You need to find the key!");
            Debug.Log("You need to find the key!");
        }
    }
}
