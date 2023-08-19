using UnityEngine;

public class ChestsManager : MonoBehaviour
{
    public static ChestsManager instance;
    public GameObject chestsUIPanel;
    public ChestsUiList ChestsUiList;
    
    public SoundEffectsPlayer soundPlayer;
    public AudioClip relic;
    public AudioClip hurt;
    public AudioClip support;
    
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        ChestsUiList = chestsUIPanel.GetComponent<ChestsUiList>();
    }
    
    public void ShowRelic(int chestIndex)
    {
        soundPlayer.playSound(relic);
        GameObject chestPanel = ChestsUiList.chestsPanelsArray[chestIndex];
        chestPanel.GetComponent<ChestUI>().ShowRelic();
    }
    
    public void ShowTrap(int chestIndex)
    {
        soundPlayer.playSound(hurt);
        GameObject chestPanel = ChestsUiList.chestsPanelsArray[chestIndex];
        chestPanel.GetComponent<ChestUI>().ShowTrap();
    }
    
    public void ShowKey(int chestIndex)
    {
        soundPlayer.playSound(support);
        GameObject chestPanel = ChestsUiList.chestsPanelsArray[chestIndex];
        chestPanel.GetComponent<ChestUI>().ShowKey();
    }
}
