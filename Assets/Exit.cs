using UnityEngine;

public class Exit : MonoBehaviour, InteractableItem
{
    public void interact()
    {
        Debug.Log("Interact with exit");
        throw new System.NotImplementedException();
    }
}
