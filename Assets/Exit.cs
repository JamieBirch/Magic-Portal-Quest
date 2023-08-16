using UnityEngine;

public class Exit : MonoBehaviour, InteractableItem
{
    private EndGame _endGameManager;
    
    private void Awake()
    {
        _endGameManager = EndGame.instance;
    }
    
    public void interact(Player player)
    {
        Debug.Log("Interact with exit");
        if (GameStats.keyFound)
        {
            GameStats.gameOver = true;
            _endGameManager.FinishGame(true);
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
