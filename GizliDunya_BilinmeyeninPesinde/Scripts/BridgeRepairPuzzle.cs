using UnityEngine;
using UnityEngine.UI;

public class BridgeRepairPuzzle : Interactable
{
    [Header("Bridge Repair Puzzle")]
    public GameObject brokenBridge; // The broken bridge object
    public GameObject[] bridgeParts; // Bridge parts to be assembled
    public Transform[] targetPositions; // Target positions for bridge parts
    public GameObject nextAreaDoor; // Door to next area
    public Text puzzleUI; // UI text to show puzzle instructions
    
    [Header("Puzzle Settings")]
    public bool[] partsPlaced; // Track which parts are placed
    public bool puzzleSolved = false;
    
    private bool isDragging = false;
    private GameObject draggedObject = null;
    private Vector3 offset;
    
    protected override void Start()
    {
        base.Start();
        interactionText = "Köprü Onarım Bulmacasını Başlat";
        
        // Initialize partsPlaced array
        partsPlaced = new bool[bridgeParts.Length];
        for (int i = 0; i < partsPlaced.Length; i++)
        {
            partsPlaced[i] = false;
        }
    }
    
    protected override void OnInteract()
    {
        if (!puzzleSolved)
        {
            StartPuzzle();
        }
    }
    
    void StartPuzzle()
    {
        Debug.Log("Köprü Onarım Bulmacası Başladı!");
        
        // Show puzzle UI
        if (puzzleUI != null)
        {
            puzzleUI.text = "Ağaç ve asma kullanarak köprüyü onarın!";
        }
        
        // Enable bridge parts interaction
        foreach (GameObject part in bridgeParts)
        {
            BridgePart bridgePart = part.GetComponent<BridgePart>();
            if (bridgePart == null)
            {
                bridgePart = part.AddComponent<BridgePart>();
                bridgePart.puzzle = this;
            }
        }
    }
    
    public void StartDragging(GameObject part)
    {
        isDragging = true;
        draggedObject = part;
        
        // Calculate offset between mouse position and object position
        Vector3 mousePosition = GetMouseWorldPosition();
        offset = part.transform.position - mousePosition;
    }
    
    public void StopDragging()
    {
        if (isDragging && draggedObject != null)
        {
            // Check if the object is near a target position
            int partIndex = System.Array.IndexOf(bridgeParts, draggedObject);
            
            for (int i = 0; i < targetPositions.Length; i++)
            {
                if (!partsPlaced[i]) // If this target position is not occupied
                {
                    float distance = Vector3.Distance(draggedObject.transform.position, targetPositions[i].position);
                    
                    if (distance < 2.0f) // If close enough to target
                    {
                        // Snap to target position
                        draggedObject.transform.position = targetPositions[i].position;
                        draggedObject.transform.rotation = targetPositions[i].rotation;
                        
                        partsPlaced[i] = true;
                        Debug.Log("Köprü parçası yerleştirildi: " + i);
                        
                        // Check if all parts are placed
                        CheckPuzzleCompletion();
                        break;
                    }
                }
            }
        }
        
        isDragging = false;
        draggedObject = null;
    }
    
    void CheckPuzzleCompletion()
    {
        bool allPlaced = true;
        foreach (bool placed in partsPlaced)
        {
            if (!placed)
            {
                allPlaced = false;
                break;
            }
        }
        
        if (allPlaced)
        {
            CompletePuzzle();
        }
    }
    
    void CompletePuzzle()
    {
        puzzleSolved = true;
        Debug.Log("Köprü onarımı tamamlandı!");
        
        if (puzzleUI != null)
        {
            puzzleUI.text = "Köprü tamir edildi! Geçide giden yol açıldı!";
        }
        
        // Open the door to next area
        if (nextAreaDoor != null)
        {
            nextAreaDoor.SetActive(false);
        }
        
        // Enable the bridge
        if (brokenBridge != null)
        {
            brokenBridge.GetComponent<Renderer>().enabled = true;
            // Add a simple bridge material to indicate it's fixed
            Material[] materials = brokenBridge.GetComponent<Renderer>().materials;
            foreach (Material mat in materials)
            {
                // Apply fixed bridge material (in a real game, you'd have a specific material)
            }
        }
    }
    
    Vector3 GetMouseWorldPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        
        if (groundPlane.Raycast(ray, out float rayDistance))
        {
            return ray.GetPoint(rayDistance);
        }
        
        return Vector3.zero;
    }
    
    void Update()
    {
        if (isDragging && draggedObject != null)
        {
            Vector3 mousePosition = GetMouseWorldPosition();
            draggedObject.transform.position = mousePosition + offset;
        }
    }
    
    protected override void OnEnterRange()
    {
        base.OnEnterRange();
        if (puzzleUI != null && !puzzleSolved)
        {
            puzzleUI.text = interactionText;
        }
    }
    
    protected override void OnExitRange()
    {
        base.OnExitRange();
        if (puzzleUI != null)
        {
            puzzleUI.text = "";
        }
    }
}