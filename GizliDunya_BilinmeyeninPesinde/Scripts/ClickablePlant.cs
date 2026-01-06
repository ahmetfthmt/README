using UnityEngine;

public class ClickablePlant : MonoBehaviour
{
    public PuzzlePlantIdentifier puzzle;
    
    void OnMouseDown()
    {
        if (puzzle != null)
        {
            puzzle.CheckPlant(gameObject);
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
}