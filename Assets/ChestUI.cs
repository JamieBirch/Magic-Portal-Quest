using UnityEngine;

public class ChestUI : MonoBehaviour
{
    public GameObject chest;
    public GameObject relic;
    public GameObject trap;
    public GameObject key;

    public void ShowRelic()
    {
        HideChest();
        relic.SetActive(true);
    }
    
    public void ShowTrap()
    {
        HideChest();
        trap.SetActive(true);
    }
    
    public void ShowKey()
    {
        HideChest();
        key.SetActive(true);
    }
    
    private void HideChest()
    {
        chest.SetActive(false);
    }
}
