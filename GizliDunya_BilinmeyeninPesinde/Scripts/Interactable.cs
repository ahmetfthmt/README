using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    [Header("Interaction Settings")]
    public string interactionText = "Eylem Yap";
    public bool isUsable = true;
    
    protected bool isInRange;
    protected PlayerController player;
    
    public virtual void Start()
    {
        isInRange = false;
    }
    
    void Update()
    {
        if (isInRange && player != null)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Interact();
            }
        }
    }
    
    public virtual void Interact()
    {
        if (!isUsable) return;
        
        OnInteract();
    }
    
    protected abstract void OnInteract();
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.GetComponent<PlayerController>();
            isInRange = true;
            OnEnterRange();
        }
    }
    
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = null;
            isInRange = false;
            OnExitRange();
        }
    }
    
    protected virtual void OnEnterRange()
    {
        // Show interaction UI
        Debug.Log("Yakınsın: " + interactionText);
    }
    
    protected virtual void OnExitRange()
    {
        // Hide interaction UI
        Debug.Log("Uzaklaştın");
    }
}