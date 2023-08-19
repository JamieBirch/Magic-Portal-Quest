using UnityEngine;

public class StarsUI : MonoBehaviour
{
    public GameObject[] starsIcons;

    public void Show(int starsCount)
    {
        for (int i = 0; i < starsCount; i++)
        {
            starsIcons[i].SetActive(true);
        }
    }
    
}
