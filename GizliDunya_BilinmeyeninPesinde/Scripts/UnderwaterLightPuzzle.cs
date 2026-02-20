using UnityEngine;
using UnityEngine.UI;

public class UnderwaterLightPuzzle : Interactable
{
    [Header("Underwater Light Puzzle")]
    public Light[] lights; // Array of lights in the puzzle
    public GameObject[] doors; // Doors controlled by the puzzle
    public Color[] lightColors; // Available colors for the lights
    public int[] targetSequence; // Target sequence to solve the puzzle
    public Text puzzleUI; // UI text to show puzzle instructions
    
    [Header("Puzzle Settings")]
    public int[] currentSequence; // Current sequence set by player
    public bool puzzleSolved = false;
    
    void Start()
    {
        base.Start();
        interactionText = "Su Altı Işık Oyunu";
        
        // Initialize current sequence
        currentSequence = new int[lights.Length];
        for (int i = 0; i < currentSequence.Length; i++)
        {
            currentSequence[i] = 0; // Start with first color
        }
        
        // Set initial light colors
        UpdateLightColors();
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
        Debug.Log("Su altı ışık oyunu başladı!");
        
        if (puzzleUI != null)
        {
            puzzleUI.text = "Işık oyunlarını çözerek kapıları açın! Işıklara tıklayarak renklerini değiştirin.";
        }
        
        // Make lights interactive
        foreach (Light light in lights)
        {
            // In a real implementation, we would add colliders to light objects
            // or create visible light objects that can be clicked
            LightPuzzlePiece piece = light.gameObject.AddComponent<LightPuzzlePiece>();
            piece.puzzle = this;
        }
    }
    
    public void ChangeLightColor(int lightIndex)
    {
        if (lightIndex >= 0 && lightIndex < lights.Length)
        {
            // Cycle to next color
            currentSequence[lightIndex] = (currentSequence[lightIndex] + 1) % lightColors.Length;
            
            // Update light color
            lights[lightIndex].color = lightColors[currentSequence[lightIndex]];
            
            Debug.Log("Işık " + lightIndex + " rengi değiştirildi: " + currentSequence[lightIndex]);
            
            // Check if puzzle is solved
            CheckSolution();
        }
    }
    
    void CheckSolution()
    {
        bool isSolved = true;
        
        for (int i = 0; i < targetSequence.Length && i < currentSequence.Length; i++)
        {
            if (currentSequence[i] != targetSequence[i])
            {
                isSolved = false;
                break;
            }
        }
        
        if (isSolved)
        {
            SolvePuzzle();
        }
    }
    
    void SolvePuzzle()
    {
        puzzleSolved = true;
        Debug.Log("Işık bulmacası çözüldü!");
        
        if (puzzleUI != null)
        {
            puzzleUI.text = "Işık oyunu çözüldü! Kapılar açılıyor!";
        }
        
        // Open all doors
        foreach (GameObject door in doors)
        {
            if (door != null)
            {
                door.SetActive(false);
            }
        }
        
        // Change all lights to a success color
        foreach (Light light in lights)
        {
            light.color = Color.green;
        }
    }
    
    void UpdateLightColors()
    {
        for (int i = 0; i < lights.Length && i < currentSequence.Length; i++)
        {
            lights[i].color = lightColors[currentSequence[i]];
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