using UnityEngine;
using UnityEngine.UI;

public class Level1Manager : MonoBehaviour
{
    [Header("Level 1: Amazon Jungle")]
    public Text levelUI; // UI text for level instructions
    public GameObject[] puzzles; // Array of puzzle objects in the level
    public int puzzlesCompleted = 0;
    public int totalPuzzles = 3; // Plant identification, Native language, Bridge repair
    
    [Header("Level Completion")]
    public GameObject levelCompleteUI; // UI shown when level is completed
    public GameObject nextLevelDoor; // Door to next level
    
    void Start()
    {
        // Initialize level UI
        if (levelUI != null)
        {
            levelUI.text = "Amazon Yağmur Ormanları'na hoşgeldiniz!\nEfsanevi 'Z Şehri'ni bulmak için 3 bulmacayı çözmelisiniz.";
        }
        
        // Initialize puzzles
        foreach (GameObject puzzle in puzzles)
        {
            puzzle.SetActive(true);
        }
        
        levelCompleteUI.SetActive(false);
    }
    
    public void RegisterPuzzleCompletion()
    {
        puzzlesCompleted++;
        Debug.Log("Bulmaca tamamlandı! (" + puzzlesCompleted + "/" + totalPuzzles + ")");
        
        // Update UI to show progress
        if (levelUI != null)
        {
            levelUI.text = "Amazon Yağmur Ormanları\n" + 
                          "Bulmacalar tamamlandı: " + puzzlesCompleted + "/" + totalPuzzles;
        }
        
        // Check if all puzzles are completed
        if (puzzlesCompleted >= totalPuzzles)
        {
            CompleteLevel();
        }
    }
    
    void CompleteLevel()
    {
        Debug.Log("Level 1 tamamlandı!");
        
        // Show level complete UI
        if (levelCompleteUI != null)
        {
            levelCompleteUI.SetActive(true);
        }
        
        // Open door to next level
        if (nextLevelDoor != null)
        {
            nextLevelDoor.SetActive(false);
        }
        
        // Update game manager
        GameManager.Instance.CompleteLevel(1);
        
        // Optional: Play completion sound
        // AudioSource.PlayClipAtPoint(completionSound, transform.position);
    }
    
    void Update()
    {
        // Optional: Add level-specific logic here
    }
}