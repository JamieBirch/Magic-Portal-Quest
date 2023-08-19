using StarterAssets;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float maxHealth = 100f;
    public float health;
    public HeartsUI HeartsUI;

    // public Image healthBar;
    
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    /*void Update()
    {
        HeartsUI.LoseHeart();
        // healthBar.fillAmount = health / maxHealth;
    }*/

    public void LoseHeart()
    {
        HeartsUI.LoseHeart();
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.TryGetComponent(out InteractableItem item))
        {
            // Debug.Log(item);
            GetComponent<FirstPersonController>().nearbyItem = hit.gameObject;
        }
    }
}
