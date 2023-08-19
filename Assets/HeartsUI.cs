using UnityEngine;

public class HeartsUI : MonoBehaviour
{
    public GameObject[] heartIcons;
    public int heartsActive = 3;

    public void LoseHeart()
    {
        heartIcons[heartsActive - 1].SetActive(false);
        heartsActive--;
    }

}
