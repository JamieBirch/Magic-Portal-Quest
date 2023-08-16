using StarterAssets;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float maxHealth = 100f;
    public float health;
    public GameObject ground;
    public GameObject wall;
    public GameObject chest;
    // public GameObject signal;
    public GameObject key;
    public GameObject exit;

    public Image healthBar;
    
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    void Update()
    {
        healthBar.fillAmount = health / maxHealth;
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
