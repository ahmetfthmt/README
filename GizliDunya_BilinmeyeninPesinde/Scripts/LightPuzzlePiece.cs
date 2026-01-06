using UnityEngine;

public class LightPuzzlePiece : MonoBehaviour
{
    public UnderwaterLightPuzzle puzzle;
    private int lightIndex;
    
    void Start()
    {
        // Find the index of this light in the puzzle's light array
        if (puzzle != null)
        {
            lightIndex = System.Array.IndexOf(puzzle.lights, GetComponent<Light>());
        }
        
        // Make sure the object is clickable by adding a collider if it doesn't have one
        // In a real implementation, we'd create a visible object that represents the light
        if (GetComponent<Collider>() == null)
        {
            // Create a sphere collider that's slightly larger than the light's range
            SphereCollider sphereCollider = gameObject.AddComponent<SphereCollider>();
            sphereCollider.radius = 1.0f; // Adjust as needed
            sphereCollider.isTrigger = true; // Make it a trigger to avoid physics issues
        }
    }
    
    void OnMouseDown()
    {
        if (puzzle != null)
        {
            puzzle.ChangeLightColor(lightIndex);
        }
    }
    
    void OnMouseEnter()
    {
        // Change material to indicate hover state (optional)
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            // In a real game, you'd have a highlighted material
            // renderer.material.color = Color.cyan;
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