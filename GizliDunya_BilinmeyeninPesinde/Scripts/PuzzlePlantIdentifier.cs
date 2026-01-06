using UnityEngine;
using UnityEngine.UI;

public class PuzzlePlantIdentifier : Interactable
{
    [Header("Plant Identification Puzzle")]
    public GameObject[] plants; // Array of plants in the scene
    public Material safePlantMaterial;
    public Material dangerousPlantMaterial;
    public GameObject nextAreaDoor; // Door to next area
    public Text puzzleUI; // UI text to show puzzle instructions
    
    [Header("Puzzle Settings")]
    public int safePlantIndex = 2; // Index of the safe plant
    public bool puzzleSolved = false;
    
    private Renderer[] plantRenderers;
    
    protected override void Start()
    {
        base.Start();
        interactionText = "Bitki Tanıma Bulmacasını Başlat";
        
        // Get all plant renderers
        plantRenderers = new Renderer[plants.Length];
        for (int i = 0; i < plants.Length; i++)
        {
            plantRenderers[i] = plants[i].GetComponent<Renderer>();
        }
        
        // Initially mark all plants as dangerous
        foreach (Renderer renderer in plantRenderers)
        {
            renderer.material = dangerousPlantMaterial;
        }
        
        // Mark the safe plant
        if (safePlantIndex >= 0 && safePlantIndex < plantRenderers.Length)
        {
            plantRenderers[safePlantIndex].material = safePlantMaterial;
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
        Debug.Log("Bitki Tanıma Bulmacası Başladı!");
        
        // Show puzzle UI
        if (puzzleUI != null)
        {
            puzzleUI.text = "Zehirli bitkileri tanıyarak güvenli yolu bulun! Doğru bitkiye yaklaşın.";
        }
        
        // Make plants clickable
        foreach (GameObject plant in plants)
        {
            ClickablePlant clickable = plant.GetComponent<ClickablePlant>();
            if (clickable == null)
            {
                clickable = plant.AddComponent<ClickablePlant>();
                clickable.puzzle = this;
            }
        }
    }
    
    public void CheckPlant(GameObject clickedPlant)
    {
        int plantIndex = System.Array.IndexOf(plants, clickedPlant);
        
        if (plantIndex == safePlantIndex)
        {
            // Correct plant selected
            Debug.Log("Doğru bitki! Güvenli yol bulundu!");
            puzzleSolved = true;
            
            if (puzzleUI != null)
            {
                puzzleUI.text = "Doğru bitki bulundu! Güvenli yol açıldı!";
            }
            
            // Open the door to next area
            if (nextAreaDoor != null)
            {
                nextAreaDoor.SetActive(false);
            }
            
            // Change all plants to safe material
            foreach (Renderer renderer in plantRenderers)
            {
                renderer.material = safePlantMaterial;
            }
        }
        else
        {
            // Wrong plant selected
            Debug.Log("Yanlış bitki! Bu bitki zehirli olabilir!");
            
            if (puzzleUI != null)
            {
                puzzleUI.text = "Yanlış bitki! Lütfen başka bir bitki deneyin.";
            }
            
            // Damage player
            if (player != null)
            {
                player.AddHealth(-10f); // Reduce health by 10
            }
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