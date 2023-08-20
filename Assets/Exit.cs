using UnityEngine;

public class Exit : MonoBehaviour, InteractableItem
{
    public PlayerMessageService MessageService;
    public GameObject fixedPortal;
    public GameObject brokenPortal;
    public GameObject effectWorking;
    public GameObject effectBroken;

    private bool broken = true;
    
    public SoundEffectsPlayer soundPlayer;
    public AudioClip support;
    
    public void interact(Player player)
    {
        Debug.Log("Interact with exit");
        if (!broken)
        {
            GameStats.gameOver = true;
            EndGame.instance.FinishGame(player, true);
            Debug.Log("You won!");
        } else if (GameStats.keyFound && broken)
        {
            soundPlayer.playSound(support);
            broken = false;
            brokenPortal.SetActive(false);
            fixedPortal.SetActive(true);
            
            effectBroken.SetActive(false);
            effectWorking.SetActive(true);
            
            MessageService.ShowMessage("You fixed the portal!");
        }
        else
        {
            MessageService.ShowMessage("You need to find the support!");
            Debug.Log("You need to find the support!");
        }
    }
}
