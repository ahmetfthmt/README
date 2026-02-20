using UnityEngine;
using UnityEngine.UI;

public class NativeLanguagePuzzle : Interactable
{
    [Header("Native Language Puzzle")]
    public Text puzzleUI; // UI text to show puzzle instructions
    public Text symbolDisplay; // Display for native symbols
    public InputField answerInput; // Input field for player answer
    public GameObject nextAreaDoor; // Door to next area
    
    [Header("Puzzle Settings")]
    public string[] nativeWords = {"Ama", "Yara", "Nuna", "Kela", "Zana"}; // Sample native words
    public string[] translations = {"Water", "Forest", "Stone", "Path", "City"}; // English translations
    public int currentPuzzleIndex = 0; // Current puzzle index
    public bool puzzleSolved = false;
    
    protected override void Start()
    {
        base.Start();
        interactionText = "Yerli Dil Bulmacasını Başlat";
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
        Debug.Log("Yerli Dil Bulmacası Başladı!");
        
        // Show puzzle UI
        if (puzzleUI != null)
        {
            puzzleUI.text = "Yerli kabilelerin dilini çözerek haritayı tamamlayın!";
        }
        
        // Display the current native word/symbol
        if (symbolDisplay != null && currentPuzzleIndex < nativeWords.Length)
        {
            symbolDisplay.text = nativeWords[currentPuzzleIndex];
        }
        
        // Enable answer input
        if (answerInput != null)
        {
            answerInput.gameObject.SetActive(true);
            answerInput.ActivateInputField();
            answerInput.onEndEdit.AddListener(OnAnswerSubmitted);
        }
    }
    
    void OnAnswerSubmitted(string answer)
    {
        if (currentPuzzleIndex < translations.Length)
        {
            if (answer.ToLower() == translations[currentPuzzleIndex].ToLower())
            {
                // Correct answer
                Debug.Log("Doğru cevap! " + nativeWords[currentPuzzleIndex] + " = " + translations[currentPuzzleIndex]);
                
                if (puzzleUI != null)
                {
                    puzzleUI.text = "Doğru cevap! " + nativeWords[currentPuzzleIndex] + " = " + translations[currentPuzzleIndex];
                }
                
                // Move to next puzzle
                currentPuzzleIndex++;
                
                if (currentPuzzleIndex >= nativeWords.Length)
                {
                    // All puzzles solved
                    CompletePuzzle();
                }
                else
                {
                    // Show next word
                    if (symbolDisplay != null)
                    {
                        symbolDisplay.text = nativeWords[currentPuzzleIndex];
                    }
                    
                    // Clear input field
                    if (answerInput != null)
                    {
                        answerInput.text = "";
                        answerInput.ActivateInputField();
                    }
                }
            }
            else
            {
                // Wrong answer
                Debug.Log("Yanlış cevap! Lütfen tekrar deneyin.");
                
                if (puzzleUI != null)
                {
                    puzzleUI.text = "Yanlış cevap! Lütfen '" + nativeWords[currentPuzzleIndex] + "' kelimesinin anlamını tekrar deneyin.";
                }
                
                // Clear input field and refocus
                if (answerInput != null)
                {
                    answerInput.text = "";
                    answerInput.ActivateInputField();
                }
                
                // Damage player slightly for wrong answer
                if (player != null)
                {
                    player.AddHealth(-5f);
                }
            }
        }
    }
    
    void CompletePuzzle()
    {
        puzzleSolved = true;
        Debug.Log("Yerli dil bulmacası tamamlandı!");
        
        if (puzzleUI != null)
        {
            puzzleUI.text = "Harita tamamlandı! Gizli şehre giden yol açıldı!";
        }
        
        // Open the door to next area
        if (nextAreaDoor != null)
        {
            nextAreaDoor.SetActive(false);
        }
        
        // Disable input field
        if (answerInput != null)
        {
            answerInput.gameObject.SetActive(false);
            answerInput.onEndEdit.RemoveListener(OnAnswerSubmitted);
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
        
        // Disable input field when leaving
        if (answerInput != null)
        {
            answerInput.gameObject.SetActive(false);
        }
    }
}