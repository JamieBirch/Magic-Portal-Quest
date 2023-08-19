using UnityEngine;

public class Exit : MonoBehaviour, InteractableItem
{
    public GameObject fixedPortal;
    public GameObject brokenPortal;

    private bool broken = true;
    
    public SoundEffectsPlayer soundPlayer;
    public AudioClip support;
    
    public void interact(Player player)
    {
        Debug.Log("Interact with exit");
        if (!broken)
        {
            GameStats.gameOver = true;
            EndGame.instance.FinishGame(true);
            Debug.Log("You won!");
        } else if (GameStats.keyFound && broken)
        {
            soundPlayer.playSound(support);
            broken = false;
            brokenPortal.SetActive(false);
            fixedPortal.SetActive(true);
            PlayerMessageService.instance.ShowMessage("You fixed the portal!");
        }
        else
        {
            PlayerMessageService.instance.ShowMessage("You need to find the support!");
            Debug.Log("You need to find the support!");
        }
    }
}
