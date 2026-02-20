using UnityEngine;

public class BridgePart : MonoBehaviour
{
    public BridgeRepairPuzzle puzzle;
    
    private bool isSelected = false;
    
    void OnMouseDown()
    {
        if (puzzle != null)
        {
            isSelected = true;
            puzzle.StartDragging(gameObject);
        }
    }
    
    void OnMouseUp()
    {
        if (isSelected && puzzle != null)
        {
            isSelected = false;
            puzzle.StopDragging();
        }
    }
    
    void Start()
    {
        // Make sure the object is clickable by adding a collider if it doesn't have one
        if (GetComponent<Collider>() == null)
        {
            gameObject.AddComponent<BoxCollider>();
        }
    }
    
    void OnMouseEnter()
    {
        // Change material to indicate hover state (optional)
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            // In a real game, you'd have a highlighted material
            // renderer.material.color = Color.yellow;
        }
    }
    
    void OnMouseExit()
    {
        // Revert material (optional)
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            // renderer.material.color = Color.white;
        }
    }
}