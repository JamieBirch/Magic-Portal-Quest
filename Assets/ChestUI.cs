using UnityEngine;

public class ChestUI : MonoBehaviour
{
    public GameObject relic;
    public GameObject trap;
    public GameObject key;

    public void ShowRelic()
    {
        relic.SetActive(true);
    }
    
    public void ShowTrap()
    {
        trap.SetActive(true);
    }
    
    public void ShowKey()
    {
        key.SetActive(true);
    }
}
