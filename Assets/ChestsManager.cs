using UnityEngine;

public class ChestsManager : MonoBehaviour
{
    public static ChestsManager instance;
    public GameObject chestsUIPanel;
    public ChestsUiList ChestsUiList;
    
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
        GameObject chestPanel = ChestsUiList.chestsPanelsArray[chestIndex];
        chestPanel.GetComponent<ChestUI>().ShowRelic();
    }
    
    public void ShowTrap(int chestIndex)
    {
        GameObject chestPanel = ChestsUiList.chestsPanelsArray[chestIndex];
        chestPanel.GetComponent<ChestUI>().ShowTrap();
    }
    
    public void ShowKey(int chestIndex)
    {
        GameObject chestPanel = ChestsUiList.chestsPanelsArray[chestIndex];
        chestPanel.GetComponent<ChestUI>().ShowKey();
    }
}
