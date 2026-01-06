using UnityEngine;
using UnityEngine.UI;

public class AtlantisAlphabetPuzzle : Interactable
{
    [Header("Atlantis Alphabet Puzzle")]
    public Text puzzleUI; // UI text to show puzzle instructions
    public Text[] symbolDisplays; // Display for Atlantis symbols
    public InputField answerInput; // Input field for player answer
    public GameObject nextAreaDoor; // Door to next area
    public AudioSource successSound; // Sound played when puzzle is solved
    
    [Header("Puzzle Settings")]
    public string[] atlantisSymbols = {"Atl", "Anr", "Kos", "Miz", "Zel", "Nuv"}; // Atlantis symbols
    public string[] meanings = {"Water", "Fire", "Earth", "Air", "Life", "Death"}; // Meanings
    public int currentPuzzleIndex = 0; // Current puzzle index
    public bool puzzleSolved = false;
    
    protected override void Start()
    {
        base.Start();
        interactionText = "Atlantis Alfabesi Bulmacası";
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
        Debug.Log("Atlantis alfabesi bulmacası başladı!");
        
        // Show puzzle UI
        if (puzzleUI != null)
        {
            puzzleUI.text = "Atlantis alfabesini kullanarak şifreli mesajları deşifre edin!";
        }
        
        // Display the current Atlantis symbol
        if (symbolDisplays.Length > 0 && currentPuzzleIndex < atlantisSymbols.Length)
        {
            symbolDisplays[0].text = atlantisSymbols[currentPuzzleIndex];
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
        if (currentPuzzleIndex < meanings.Length)
        {
            if (answer.ToLower() == meanings[currentPuzzleIndex].ToLower())
            {
                // Correct answer
                Debug.Log("Doğru! " + atlantisSymbols[currentPuzzleIndex] + " = " + meanings[currentPuzzleIndex]);
                
                if (puzzleUI != null)
                {
                    puzzleUI.text = "Doğru! " + atlantisSymbols[currentPuzzleIndex] + " = " + meanings[currentPuzzleIndex];
                }
                
                // Move to next puzzle
                currentPuzzleIndex++;
                
                if (currentPuzzleIndex >= atlantisSymbols.Length)
                {
                    // All puzzles solved
                    CompletePuzzle();
                }
                else
                {
                    // Show next symbol
                    if (symbolDisplays.Length > 0)
                    {
                        symbolDisplays[0].text = atlantisSymbols[currentPuzzleIndex];
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
                Debug.Log("Yanlış cevap! '" + answer + "' değil '" + meanings[currentPuzzleIndex] + "'");
                
                if (puzzleUI != null)
                {
                    puzzleUI.text = "Yanlış cevap! '" + atlantisSymbols[currentPuzzleIndex] + "' sembolünün anlamını tekrar deneyin.";
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
        Debug.Log("Atlantis alfabesi bulmacası tamamlandı!");
        
        if (puzzleUI != null)
        {
            puzzleUI.text = "Atlantis kütüphanesine giden yol açıldı!";
        }
        
        // Play success sound
        if (successSound != null)
        {
            successSound.Play();
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