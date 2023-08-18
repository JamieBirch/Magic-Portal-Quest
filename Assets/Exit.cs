using UnityEngine;

public class Exit : MonoBehaviour, InteractableItem
{
    public GameObject fixedPortal;
    public GameObject brokenPortal;
    /*private EndGame _endGameManager;
    
    private void Awake()
    {
        _endGameManager = EndGame.instance;
    }*/
    
    public void interact(Player player)
    {
        Debug.Log("Interact with exit");
        if (GameStats.keyFound)
        {
            brokenPortal.SetActive(false);
            fixedPortal.SetActive(true);
            GameStats.gameOver = true;
            EndGame.instance.FinishGame(true);
            PlayerMessageService.instance.ShowMessage("You won!");
            Debug.Log("You won!");
        }
        else
        {
            PlayerMessageService.instance.ShowMessage("You need to find the support!");
            Debug.Log("You need to find the support!");
        }
    }
}
