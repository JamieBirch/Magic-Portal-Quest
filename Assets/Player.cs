using StarterAssets;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health;
    public GameObject ground;
    public GameObject wall;
    public GameObject chest;
    // public GameObject signal;
    public GameObject key;
    public GameObject exit;

    
    // Start is called before the first frame update
    void Start()
    {
        health = 100;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.TryGetComponent(out InteractableItem item))
        {
            Debug.Log(item);
            GetComponent<FirstPersonController>().nearbyItem = hit.gameObject;
        }
    }
}
